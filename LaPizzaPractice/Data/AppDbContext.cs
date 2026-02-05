using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using LaPizzaPractice.Models;

namespace LaPizzaPractice.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ActiveStatus> ActiveStatSet { get; set; }
        public DbSet<Address> AddressSet { get; set; }
        public DbSet<Categories> CategoriesSet { get; set; }
        public DbSet<Clients> ClientsSet { get; set; }
        public DbSet<Orders> OrdersSet { get; set; }
        public DbSet<Products> ProductsSet { get; set; }
        public DbSet<Roles> RolesSet { get; set; }
        public DbSet<UserAuthoriz> UserAuthoSet { get; set; }
        public DbSet<WorkerAuthoriz> WorkerAuthoSet { get; set; }
        public DbSet<WorkerPerData> WorkerPersDataSet { get; set; }
        public DbSet<Workers> WorkersSet { get; set; }
    }
}
