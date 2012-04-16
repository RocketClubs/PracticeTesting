using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PracticeTesting
{
    [Serializable]
    [XmlType("Diagram")]
    public class MultipleChoiceDiagram
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("uri")]
        public string Uri { get; set; }

        [XmlAttribute("source")]
        public string Source { get; set; }

        public MultipleChoiceDiagram()
        {
        }
    }
}
