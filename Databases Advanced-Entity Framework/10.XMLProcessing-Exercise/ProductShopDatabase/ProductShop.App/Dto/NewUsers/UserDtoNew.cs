using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ProductShop.App.Dto.Export;

namespace ProductShop.App.Dto.NewUsers
{
    [XmlType("user")]
    public class UserDtoNew
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public SoldProductDto SoldProducts { get; set; }
    }
}
