using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch16_QuizModels
{
    public class Quiz
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //一对多关系集合
        public virtual ICollection<Question> Questions { get; set; }
        //构造函数中初始化集合，防止空引用异常
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}
