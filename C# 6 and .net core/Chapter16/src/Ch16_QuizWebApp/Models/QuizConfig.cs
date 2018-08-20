using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ch16_QuizModels;
using Microsoft.EntityFrameworkCore;
using Ch16_QuizRepository;

namespace Ch16_QuizWebApp.Models
{
    public static class QuizConfig
    {
        public static void UseSampleQuestions(this IApplicationBuilder builder,string path)
        {
            //加载json文件
            string json = File.ReadAllText(Path.Combine(path, "SampleQuestions.json"));
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All };

            List<Quiz> quizzes = JsonConvert.DeserializeObject<List<Quiz>>(json,setting);

            //配置内存数据库选项
            var optionBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionBuilder.UseInMemoryDatabase();

            using (var context=new QuizContext(optionBuilder.Options))
            {
                //将每个quiz和他的question实体标记为添加状态
                foreach (var quiz in quizzes)
                {
                    context.Add(quiz);
                }
                //将实体保存到数据存储
                context.SaveChanges();
            }
        }
    }
}
