using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dto.NewUsers
{
    [XmlType("sold-product")]
    public class SoldProductDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("product")]
        public ProductDtoSold[] Products { get; set; }
    }
}
