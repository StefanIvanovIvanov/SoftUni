using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                var type = Type.GetType("P01_HarvestingFields.HarvestingFields");
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                switch (input)
                {
                    case "private":
                        fields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        fields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                    //    fields = fields;
                        break;
                }
                string modifier;
                foreach (var field in fields)
                {
                    modifier = GetModifier(field);
                    Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static string GetModifier(FieldInfo field)
        {
            if (field.IsFamily)
            {
                return "protected";
            }
            else if (field.IsPrivate)
            {
                return "private";
            }
            else if (field.IsPublic)
            {
                return "public";
            }
            else
            {
                return "no such modifier";
            }
        }
    }
}
