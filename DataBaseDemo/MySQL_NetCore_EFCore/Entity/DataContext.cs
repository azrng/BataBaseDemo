using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySQL_NetCore_EFCore.Entity
{
    public class DataContext : DbContext
    {
        private IConfiguration configuration;
        public DataContext()
        {
            //需要引用Microsoft.Extensions.Configuration.Json
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"));
        }

        public virtual DbSet<UserInfoEntity> UserInfoEntities { get; set; }

    }
}
