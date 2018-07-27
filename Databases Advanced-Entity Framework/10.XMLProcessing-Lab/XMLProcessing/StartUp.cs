using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLProcessing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Library lib = new Library() { Id = 2, Name = "Varna lib" };

            XmlSerializer serializer = new XmlSerializer(typeof(Library));

            using (var writter = new StreamWriter("library.xml"))
            {
                serializer.Serialize(writter, lib);
            }

            using (var reader = new StreamReader("library.xml"))
            {
                lib = (Library)serializer.Deserialize(reader);
            }

            using (var reader = new StreamReader("library.xml"))
            {
                XDocument document = XDocument.Load(reader);

                var titles = document.Root.Element("books")
                    .Elements("book")
                    .Select(x => x
                        .Element("bookTitle").Value
                    ).ToList();

                Console.WriteLine(String.Join(Environment.NewLine,titles));
            }



            //Parsing XML

            //            string str =
            //                @"<?xml version=""1.0""?>
            //<!--comment at the root level-->
            //<Root>
            //    <Child>Content</Child>
            //</Root>";
            //
            //            XDocument doc = XDocument.Parse(str);



            //XDocument doc2 = XDocument.Load("../../cars.xml");




            //Getting Elements

            //var cars = doc2.Root.Elements();

            //foreach (var car in cars)
            //{
            //    string make = car.Element("make").Value;
            //    string model = car.Element("model").Value;
            //    Console.WriteLine($"{make}{model}");
            //}




            //Getting Attreibutes

            //var custName = customer.Attribute("name").Value;
            //
            //var attributes = customer.Attributes;




            //Searching in XML with LINQ

            //XDocument xmlDoc = XDocument.Load("cars.xml");
            //var cars = xmlDoc.Root.Elements()
            //    .Where(e => e.Element("make").Value == "Opel" &&
            //                (long)e.Element("travelled-distance") >= 300000)
            //    .Select(c => new
            //    {
            //        Model = c.Element("model").Value,
            //        Traveled = c.Element("travelled-distance").Value
            //    })
            //    .ToList();
            //foreach (var car in cars)
            //    Console.WriteLine(car.Model + " " + car.Traveled);




            //Creating XML with XElement

            //XDocument xmlDoc2 = new XDocument();
            //xmlDoc.Add(
            //    new XElement("books",
            //        new XElement("book",
            //            new XElement("author", "Don Box"),
            //            new XElement("title", "ASP.NET", new XAttribute("lang", "en"))
            //        )));
            //
            //xmlDoc2.Save("myBooks.xml");




            //Searializing XML to File
            //var serializer = new XmlSerializer(typeof(ProductDTO));
            //using (var writer = new StreamWriter("myProduct.xml");)
            //{
            //    serializer.Serialize(writer, product);
            //}




            //Deserializing object from XML string
            //var serializer = new XmlSerializer(typeof(OrderDto[]), new XmlRootAttribute("Orders"));
            //
            //var deserializedOrders =
            //    (OrderDto[])serializer.Deserialize(new StringReader(xmlString));


            //Specify Root Attribute name
            //var attr = new XmlRootAttribute("Orders");
            //var serializer = new XmlSerializer(typeof(OrderDto[]), attr);
            //
            //var deserializedOrders =
            //    (OrderDto[])serializer.Deserialize(new StringReader(xmlString));
        }
    }
}
