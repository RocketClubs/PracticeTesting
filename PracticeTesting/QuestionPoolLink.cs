using System;
using System.Xml.Serialization;

namespace RocketClubs.Study.PracticeTesting
{
    [Serializable]
    [XmlType("Link")]
    public class QuestionPoolLink
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
        
        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlAttribute("toolTip")]
        public string ToolTip { get; set; }

        public QuestionPoolLink(QuestionPoolLink original)
        {
            this.Url = original.Url;
            this.Text = original.Text;
            this.ToolTip = original.ToolTip;
        }

        public QuestionPoolLink()
        {
        }
    }
}
