using System;
using System.Collections.Generic;
using System.Linq;

namespace RocketClubs.Study.PracticeTesting
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
                return Questions.Count(a => a.Correct);
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
