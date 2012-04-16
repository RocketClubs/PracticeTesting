using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeTesting
{
    public class PracticeTestQuestion : MultipleChoiceQuestion
    {
        public MultipleChoiceAnswer AnswerChosen { get; set; }

        public string Section { get; private set; }

        public string QuestionId
        {
            get
            {
                return String.Format("{0}-{1}", this.Section, this.Number);
            }
        }

        public bool Correct
        {
            get
            {
                return AnswerChosen == null ? false : AnswerChosen.Correct;
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
