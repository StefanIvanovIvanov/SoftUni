using System;
using System.Linq;
using AutoMapper;
using AutoMapping;

namespace AutoMapping
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new AutoMapperContext();

            //Manual Mapping
            Product product = new Product();

            ProductDTO productDto = new ProductDTO
            {
                Name = product.Name,
                StockQty = product.ProductStocks.Sum(ps => ps.Quantity)
            };

            //AutoMapper
            //Install-Package AutoMapper

            //Initialization and Configuration
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());

            product = context.Products.FirstOrDefault();
            ProductDTO newDto = Mapper.Map<ProductDTO>(product);

            //Or you can configure all mapping configurations at once
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Product, ProductDTO>();
            //    cfg.CreateMap<Order, OrderDTO>();
            //    cfg.CreateMap<Client, ClientDTO>();
            //    cfg.CreateMap<SupportTicket, TicketDTO>();
            //});


            //Map properties that don't match naming convention
            Mapper.Initialize(cfg =>
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dto => dto.StockQty,
                        opt => opt.MapFrom(src =>
                            src.ProductStocks.Sum(p => p.Quantity))));

            //AutoMapper can also be used to flatten complex properties
            //Mapper.Initialize(cfg =>
            //    cfg.CreateMap<Event, CalendarEventViewModel>()
            //        .ForMember(dest => dest.Date,
            //            opt => opt.MapFrom(src => src.Date.Date))
            //        .ForMember(dest => dest.Hour,
            //            opt => opt.MapFrom(src => src.Date.Hour))
            //        .ForMember(dest => dest.Minute,
            //            opt => opt.MapFrom(src => src.Date.Minute)));


            //Using AutoMapper to map an entire DB collection
            //var posts = context.Posts
            //    .Where(p => p.Author.Username == "gosho")
            //    .ProjectTo<PostDto>()
            //    .ToArray();


            //Profile
            //We can extract our configuration to a class (Profile)

            //using the configuration Profile class
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMappingProfile>());
        }
    }
}
