using System;
using System.Xml.Serialization;

namespace RocketClubs.Study.PracticeTesting
{
    [Serializable]
    [XmlType("Section")]
    public class QuestionPoolSection
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlAttribute("numberOnTest")]
        public int NumberOnTest { get; set; }

        [XmlElement("Question")]
        public MultipleChoiceQuestion[] Questions { get; set; }

        public QuestionPoolSection(QuestionPoolSection original)
        {
            if (original == null) throw new ArgumentNullException("original");

            this.Name = original.Name;
            this.Description = original.Description;
            this.NumberOnTest = original.NumberOnTest;
            this.Questions = (MultipleChoiceQuestion[])original.Questions.Clone();
        }

        public QuestionPoolSection()
        {
        }
    }
}
