using System;
using System.Xml.Serialization;

namespace RocketClubs.Study.PracticeTesting
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
    }
}
