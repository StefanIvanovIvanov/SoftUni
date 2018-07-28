using System;
using System.Collections.Generic;
using DataAnotations = System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.App.Dto;
using ProductShop.App.Dto.Export;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //AutoMapper
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = config.CreateMapper();

            //Users:


            //Reading the .xml file
            //var xmlString = File.ReadAllText(@"../../../Xml/users.xml");

            //var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            //var reader = new StringReader(xmlString);
            //var deserializedUsers = (UserDto[])serializer.Deserialize(reader);

            //List<User> users = new List<User>();
            //
            //foreach (var userDto in deserializedUsers)
            //{
            //    if (isValid(userDto))
            //    {
            //        continue;
            //    }
            //
            //    var user = mapper.Map<User>(userDto);
            //
            //    users.Add(user);
            //}
            //
            //var context = new ProductShopContext();
            //context.Users.AddRange(users);
            //context.SaveChanges();



            //Products:


            //var xmlString = File.ReadAllText(@"../../../Xml/products.xml");           
            //
            //var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            //var reader = new StringReader(xmlString);
            //var deserializedUsers = (ProductDto[])serializer.Deserialize(reader);
            //
            //List<Product> products = new List<Product>();
            //
            //int counter = 1;
            //
            //foreach (var productDto in deserializedUsers)
            //{
            //    if (isValid(productDto))
            //    {
            //        continue;
            //    }
            //
            //    var product = mapper.Map<Product>(productDto);
            //
            //    var buyerId = new Random().Next(1, 30);
            //    var sellerId = new Random().Next(1, 30);
            //
            //    product.BuyerId = buyerId;
            //    product.SellerId = sellerId;
            //
            //    if (counter == 4)
            //    {
            //        product.BuyerId = null;
            //        counter = 0;
            //    }
            //
            //    products.Add(product);
            //
            //    counter++;
            //}
            //
            //var context = new ProductShopContext();
            //context.Products.AddRange(products);
            //context.SaveChanges();  



            //Categories:

            //var xmlString = File.ReadAllText(@"../../../Xml/categories.xml");
            //
            //var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            //
            //var deserializedCategores = (CategoryDto[]) serializer.Deserialize(new StringReader(xmlString));
            //
            //var categories = new List<Category>();
            //
            //foreach (var categoryDto in deserializedCategores)
            //{
            //    if (!isValid(categoryDto))
            //    {
            //        continue;
            //    }
            //
            //    var category = mapper.Map<Category>(categoryDto);
            //
            //    categories.Add(category);
            //}
            //
            //var context=new ProductShopContext();
            //context.Categories.AddRange(categories);
            //context.SaveChanges();

            //var categoryProducts = new List<CategoryProduct>();
            //
            //for (int productId = 201; productId < 400; productId++)
            //{
            //    var categoryId = new Random().Next(1, 11);
            //
            //    var categoryProduct = new CategoryProduct()
            //    {
            //        ProductId = productId,
            //        CategoryId = categoryId
            //    };
            //    categoryProducts.Add(categoryProduct);          
            //}



            //XML to DTO

            //var context = new ProductShopContext();
            //
            //var products = context.Products
            //    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
            //    .OrderByDescending(p => p.Price)
            //    .Select(x => new ProductDtoExport()
            //    {
            //        Name = x.Name,
            //        Price = x.Price,
            //        Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
            //    })
            //    .ToArray();
            //
            //
            //StringBuilder sb = new StringBuilder();
            //var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            //var serializer = new XmlSerializer(typeof(ProductDtoExport[]), new XmlRootAttribute("products"));
            //serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);
            //
            //File.WriteAllText("products-in-range.xml", sb.ToString());

            var context = new ProductShopContext();

            var users = context.Users
                .Select(x => new UserDtoExport
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(UserDtoExport[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);
            
            File.WriteAllText("users-sold-prodducts.xml", sb.ToString());
        }

        public static bool isValid(object obj)
        {
            var validationContext = new DataAnotations.ValidationContext(obj);
            var validationResults = new List<DataAnotations.ValidationResult>();

            return DataAnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
