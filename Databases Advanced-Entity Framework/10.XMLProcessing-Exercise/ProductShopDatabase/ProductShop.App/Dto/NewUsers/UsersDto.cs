using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ProductShop.App.Dto.Export;

namespace ProductShop.App.Dto.NewUsers
{
    [XmlRoot("users")]
    public class UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }    

        [XmlElement("users")]
        public UserDtoNew[] Users { get; set; }
    }
}
