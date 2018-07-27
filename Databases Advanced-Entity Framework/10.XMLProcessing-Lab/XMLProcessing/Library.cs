using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLProcessing
{
    [XmlRoot(ElementName = "library")]

    public class Library
    {
        [XmlAttribute("id")]

        public int Id { get; set; }

        [XmlElement("libraryName")]

        public string Name { get; set; }

        [XmlArray(ElementName = "books")]

        public Book[] Books { get; set; } = new Book[2]
        {
            new Book(){Author = "Stephen King", Title="IT", ISBN = "ASD-123-ASD"},
            new Book(){Author = "Stephen King", Title="Shining", ISBN = "DFG-456-DFG"}
        };
    }
}
