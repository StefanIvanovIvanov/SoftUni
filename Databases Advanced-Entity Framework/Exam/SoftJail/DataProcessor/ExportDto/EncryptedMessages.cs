using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{[XmlType("EncryptedMessages")]
    public class EncryptedMessages
    {
        [XmlElement("Message")]
        public string Message { get; set; }

        [XmlElement("Description")]
        public Description Description { get; set; }
    }
    
}
