using System;
using AutoMapping.Data;
using AutoMapping.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AutoMapping.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly AutoMappingContext context;

        public DbInitializerService(AutoMappingContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
