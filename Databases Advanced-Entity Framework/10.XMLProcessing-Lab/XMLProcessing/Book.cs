using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLProcessing
{
    [XmlType("book")]
    public class Book
    {
        [XmlElement("bookTitle")]

        public string Title { get; set; }

        [XmlElement("author")]

        public string Author { get; set; }

        [XmlElement("isbn")]

        public string ISBN { get; set; }
    }
}
