using System;

namespace RocketClubs.Study.PracticeTesting
{
    public class PracticeTestQuestion : MultipleChoiceQuestion
    {
        public MultipleChoiceAnswer AnswerChosen { get; set; }

        public string Section { get; private set; }

        public string QuestionId
        {
            get
            {
                // TODO: this is really hard coded for my own representation, really a display property
                return String.Format("{0}-{1}", this.Section, this.Number);
            }
        }

        public bool Correct
        {
            get
            {
                return AnswerChosen != null && AnswerChosen.Correct;
            }
        }

        public PracticeTestQuestion(MultipleChoiceQuestion question, string section)
            : base(question)
        {
            this.Section = section;
        }

        public PracticeTestQuestion(MultipleChoiceQuestion question)
            : this(question, null)
        {
        }

        public override string ToString()
        {
            return QuestionId;
        }
    }
}
