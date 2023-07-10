﻿using Microsoft.EntityFrameworkCore;


namespace WebAppCrud.DB
{
    public class DBContext1 : DbContext
    {
        public DBContext1(DbContextOptions<DBContext1> options) : base(options)
        {
        }
        public DbSet<Prod> Prods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
