using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace PracticeTesting
{
    [Serializable]
    [XmlRoot("QuestionPool", Namespace="http://www.bactum.org/practicetesting/")]
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
            List<PracticeTestQuestion> questions = new List<PracticeTestQuestion>();
            
            this.Sections.ToList().ForEach(section => {
                var current = from question in section.Questions.GetRandomSubset(section.NumberOnTest).OrderBy(q => q.Number)
                              select new PracticeTestQuestion(question, section.Name);

                questions.AddRange(current);
            });

            PracticeTest practiceTest = PracticeTest.Create(this.Name, this.PassingScore, this.RandomizeTestOrder ? questions.Randomize() : questions);
            return practiceTest;
        }

        public PracticeTest CreatePracticeTest(IEnumerable<string> questionIds)
        {
            List<PracticeTestQuestion> questions = new List<PracticeTestQuestion>();

            foreach (string questionName in questionIds)
            {
                string[] parts = questionName.Split(new string[] { "-" }, StringSplitOptions.None);
                string sectionName = parts[0];
                int questionNumber = Convert.ToInt32(parts[1]);
                MultipleChoiceQuestion question = this.Sections.First(s => s.Name == parts[0]).Questions.First(q => q.Number == questionNumber);
                questions.Add(new PracticeTestQuestion(question, sectionName));
            }

            PracticeTest practiceTest = PracticeTest.Create(this.Name, this.PassingScore, this.RandomizeTestOrder ? questions.Randomize() : questions);
            return practiceTest;
        }

        public static QuestionPool LoadFromXmlFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionPool));

            using (XmlTextReader reader = new XmlTextReader(fileName))
            {
                try
                {
                    QuestionPool questionPool = (QuestionPool)serializer.Deserialize(reader);
                    return questionPool;
                }
                catch (XmlException)
                {
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
