using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Description")]
    public class Description
    {
        [XmlText]
        public string Text { get; set; }
    }
}
