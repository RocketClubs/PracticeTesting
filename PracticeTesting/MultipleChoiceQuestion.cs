using System;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace PracticeTesting
{
    [Serializable]
    [XmlType("Question")]
    public class MultipleChoiceQuestion
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlElement("Prompt")]
        public string Prompt 
        {
            get
            {
                return this._Prompt;
            }
            set
            {
                this._Prompt = CommonRegex.ReduceWhitespace(value);
            }
        }
        private string _Prompt;

        [XmlElement("Answer")]
        public MultipleChoiceAnswer[] Choices { get; set; }

        [XmlElement("Diagram")]
        public MultipleChoiceDiagram[] Diagrams { get; set; }

        public MultipleChoiceQuestion(MultipleChoiceQuestion original)
        {
            if (original == null) throw new ArgumentNullException("original");

            this.Prompt = original.Prompt;
            this.Number = original.Number;

            if (original.Choices != null) this.Choices = (MultipleChoiceAnswer[])original.Choices.Clone();
            if (original.Diagrams != null) this.Diagrams = (MultipleChoiceDiagram[])original.Diagrams.Clone();
        }

        public MultipleChoiceQuestion()
        {
        }
    }
}
