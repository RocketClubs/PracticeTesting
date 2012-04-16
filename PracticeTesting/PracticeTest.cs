using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeTesting
{
    public class PracticeTest
    {
        public string Name { get; private set; }
        public int PassingScore { get; private set; }

        public IEnumerable<PracticeTestQuestion> Questions { get; private set; }

        public int TotalCorrect
        {
            get
            {
                int numCorrect = this.Questions.Where(a => a.Correct == true).Count();
                return numCorrect;
            }
        }

        protected PracticeTest()
        {
        }

        public static PracticeTest Create(string name, int passingScore, IEnumerable<PracticeTestQuestion> questions)
        {
            if (questions == null) throw new ArgumentNullException("questions");

            return new PracticeTest
            {
                Name = name,
                Questions = questions.ToArray(),
                PassingScore = passingScore,
            };
        }
    }
}
