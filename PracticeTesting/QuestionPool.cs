using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace RocketClubs.Study.PracticeTesting
{
    [Serializable]
    [XmlRoot("QuestionPool", Namespace="http://www.rocketclubs.com/study/practicetesting/")]
    public class QuestionPool
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlAttribute("randomizeTestOrder")]
        public bool RandomizeTestOrder { get; set; }

        [XmlElement("Version")]
        public string Version { get; set; }

        [XmlElement("Organization")]
        public string Organization { get; set; }

        [XmlElement("OrganizationWebsite")]
        public string OrganizationWebsite { get; set; }

        [XmlElement("Link")]
        public QuestionPoolLink[] Links { get; set; }

        [XmlElement("PassingScore")]
        public int PassingScore { get; set; }

        [XmlElement("Section")]
        public QuestionPoolSection[] Sections { get; set; }

        public PracticeTest CreatePracticeTest()
        {
            var questions = new List<PracticeTestQuestion>();
            
            Sections.ToList().ForEach(section => {
                var current = from question in section.Questions.GetRandomSubset(section.NumberOnTest).OrderBy(q => q.Number)
                              select new PracticeTestQuestion(question, section.Name);

                questions.AddRange(current);
            });

            var practiceTest = PracticeTest.Create(Name, PassingScore, RandomizeTestOrder ? questions.Randomize() : questions);
            return practiceTest;
        }

        public PracticeTest CreatePracticeTest(IEnumerable<string> questionIds)
        {
            var questions = new List<PracticeTestQuestion>();

            foreach (var questionName in questionIds)
            {
                var parts = questionName.Split(new string[] { "-" }, StringSplitOptions.None);
                var sectionName = parts[0];
                var questionNumber = Convert.ToInt32(parts[1]);
                var question = Sections.First(s => s.Name == parts[0]).Questions.First(q => q.Number == questionNumber);
                questions.Add(new PracticeTestQuestion(question, sectionName));
            }

            var practiceTest = PracticeTest.Create(Name, PassingScore, RandomizeTestOrder ? questions.Randomize() : questions);
            return practiceTest;
        }

        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(QuestionPool));

        public static QuestionPool LoadFromXmlFile(string fileName)
        {
            using (var reader = new XmlTextReader(fileName))
            {
                try
                {
                    var questionPool = (QuestionPool)Serializer.Deserialize(reader);
                    return questionPool;
                }
                catch (XmlException)
                {
                    // TODO: these are great places to log errors...
                    return null;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }
    }
}
