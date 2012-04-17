using System;
using System.Xml.Serialization;

namespace RocketClubs.Study.PracticeTesting
{
    [Serializable]
    [XmlType("Answer")]
    public class MultipleChoiceAnswer
    {
        [XmlAttribute("choice")]
        public string OptionId { get; set; }

        [XmlText]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = CommonRegex.ReduceWhitespace(value);
            }
        }
        private string _Text;

        [XmlAttribute("correct")]
        public bool Correct { get; set; }

        public MultipleChoiceAnswer(MultipleChoiceAnswer original)
        {
            if (original == null) throw new ArgumentNullException("original");

            this.Correct = original.Correct;
            this._Text = original._Text;
            this.OptionId = original.OptionId;
        }

        public MultipleChoiceAnswer()
        {
        }
    }
}
