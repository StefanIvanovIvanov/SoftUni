using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonProcessing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Serializing

            string SerializeJson<User>(User user)

            {
                var serializer = new DataContractJsonSerializer(user.GetType());

                using (var stream = new MemoryStream())

                {

                    serializer.WriteObject(stream, user);

                    var result = Encoding.UTF8.GetString(stream.ToArray());

                    return result;
                }
            }

            //Deserializing

            User DeserializeJson<User>(string jsonString)
            {
                var serializer = new DataContractJsonSerializer(typeof(User));

                var jsonStringBytes = Encoding.UTF8.GetBytes(jsonString);

                using (var stream = new MemoryStream(jsonStringBytes))
                {
                    var result = (User)serializer.ReadObject(stream);

                    return result;
                }
            }

            //Json.NET
            //Install-Package Newtonsoft.Json

            //Serializing with Json.NET

            Product product = new Product();

            var jsonProduct = JsonConvert.SerializeObject(product);
            //var jsonProduct = JsonConvert.SerializeObject(product, Formatting.Indented);

            //Deserialize with Json.NET

            var objProduct = JsonConvert.DeserializeObject<Product>(jsonProduct);


            //Deserialize anonymous types

            string json = @"{ 'firstName': 'Vladimir',

'lastName': 'Georgiev',
'jobTitle': 'Technical Trainer' }";

            var template = new
            {
                FirstName = string.Empty,

                LastName = string.Empty,

                Occupation = string.Empty
            };

            var person = JsonConvert.DeserializeAnonymousType(json, template);

            //LINQ to JSON

            json = @"{ 'firstName': 'Vladimir',

'lastName': 'Georgiev',
'jobTitle': 'Technical Trainer' }";

            JObject obj = JObject.Parse(json);

            var people = JObject.Parse(File.ReadAllText(@"c:\people.json"));

            //each person in the Json is a separate JToken
            foreach (JToken person in people)
            {
                Console.WriteLine(person["FirstName"]);

                Console.WriteLine(person["LastName"]);
            }

            //Objects can be queried with LINQ
             json = JObject.Parse(@"{'products': [

{'name': 'Fruits', 'products': ['apple', 'banana']},

{'name': 'Vegetables', 'products': ['cucumber']}]}");

            var products = json["products"].Select(t =>

               string.Format("{0} ({1})",

                   t["name"],

                   string.Join(", ", c["products"])

               ));
            // Fruits (apple, banana)
            // Vegetables (cucumber)
        }

    }
}
