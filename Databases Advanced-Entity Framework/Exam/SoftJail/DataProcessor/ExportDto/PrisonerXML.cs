using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonerXML
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string FullName { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("Messages")]
        public Mail[] EncryptedMessages { get; set; }
    }
}
