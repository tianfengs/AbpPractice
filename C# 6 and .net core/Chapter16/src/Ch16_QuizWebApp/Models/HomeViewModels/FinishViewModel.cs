using Ch16_QuizModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch16_QuizWebApp.Models.HomeViewModels
{
    public class FinishViewModel
    {
        public Quiz Quiz { get; set; }
        public Dictionary<int,string> Answers { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
