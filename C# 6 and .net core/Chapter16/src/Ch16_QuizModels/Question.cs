namespace Ch16_QuizModels
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        //一对多关系的另一端
        public virtual Quiz Quiz { get; set; }
    }
}