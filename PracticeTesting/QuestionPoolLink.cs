using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PracticeTesting
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
