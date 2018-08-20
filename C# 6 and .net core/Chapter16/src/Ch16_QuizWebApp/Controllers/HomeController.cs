using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ch16_QuizRepository;
using Newtonsoft.Json;
using Ch16_QuizModels;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ch16_QuizWebApp.Models.HomeViewModels;

namespace Ch16_QuizWebApp.Controllers
{
    public class HomeController : Controller
    {
        private QuizContext db;
        public JsonSerializerSettings setting = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.All
        };

        #region 在Session中存储状态的帮助方法
        public void SetQuiz(Quiz input)
        {
            string json = JsonConvert.SerializeObject(input, Formatting.None, setting);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            HttpContext.Session.Set("usersquiz", jsonBytes);
        }

        public Quiz GetQuiz()
        {
            byte[] jsonBytes = default(byte[]);
            if (HttpContext.Session.TryGetValue("usersquiz",out jsonBytes))
            {
                string json = Encoding.UTF8.GetString(jsonBytes);
                return JsonConvert.DeserializeObject<Quiz>(json);
            }
            return null;
        }

        public void SetAnswers(Dictionary<int,string> input)
        {
            byte[] answers = default(byte[]);
            string json = JsonConvert.SerializeObject(input);
            answers = Encoding.UTF8.GetBytes(json);
            HttpContext.Session.Set("usersanswers",answers);
        }
        public Dictionary<int,string> GetAnswers()
        {
            byte[] answers = default(byte[]);
            if (HttpContext.Session.TryGetValue("usersanswers",out answers))
            {
                string json = Encoding.UTF8.GetString(answers);
                return JsonConvert.DeserializeObject<Dictionary<int,string>>(json);
            }
            return null;
        }
        #endregion

        public HomeController()
        {
            var optionBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionBuilder.UseInMemoryDatabase();
            db = new QuizContext(optionBuilder.Options);
        }
        //使用异步改善伸缩性
        [ResponseCache(NoStore =false,Duration =3600,VaryByHeader ="Accept")]
        public async Task<IActionResult> Index()
        {
            var vm =await db.Quizs.ToListAsync();
            ViewData["Title"] = "Home";
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult TakeQuiz(string id)
        {
            var model = db.Quizs.Where(q => q.Id == id).Include(q => q.Questions).FirstOrDefault();
            if (model == null)
            {
                return NotFound($"没有找到id={id}的测试题");
            }
            SetQuiz(model);
            SetAnswers(new Dictionary<int, string>());
            ViewData["Title"] = "Take Quiz";
            return View(model);
        }

        public IActionResult Question(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("必须传入问题的Id");
            }
            var quiz = GetQuiz();
            var answers = GetAnswers();
            var model = new QuestionViewModel
            {
                Question = quiz.Questions.Skip(id.Value - 1).Take(1).FirstOrDefault(),
                Answer = answers.ContainsKey(id.Value - 1) ? answers[id.Value - 1] : string.Empty,
                Number = id.Value,
                Total = quiz.Questions.Count()
            };
            ViewData["Title"] = $"Question {model.Number} of {model.Total}";
            return View(model);
        }

        [HttpPost]
        public IActionResult Question(int? id, string submit, string answer)
        {
            if (!id.HasValue)
            {
                return NotFound("必须传入问题的Id");
            }
            var answers = GetAnswers();
            answers[id.Value - 1] = answer;
            SetAnswers(answers);
            if (submit == "Previous")
            {
                id--;
            }
            else if (submit == "Next")
            {
                id++;
            }
            else if (submit == "Finish")
            {
                return RedirectToAction("Finish");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Question", new { id = id });
        }

        public IActionResult Finish()
        {
            var quiz = GetQuiz();
            var model = new FinishViewModel
            {
                Quiz = quiz,
                Answers = GetAnswers()
            };
            for (int i = 0; i < model.Quiz.Questions.Count; i++)
            {
                if (model.Quiz.Questions.ToList()[i].CorrectAnswer == model.Answers[i]) model.CorrectAnswers++;
            }
            ViewData["Title"] = "End of Quiz";
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
