using LaPizzaPractice.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaPizzaPractice.Factory
{
    public static class DbContextFactory
    {
        private static readonly string _dbConnectSrting =
            "Host=localhost;Port=5432;Database=la_pizza_project;Username=postgres;Password=postgres";

        public static AppDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(_dbConnectSrting)
                .Options;

            return new AppDbContext(options);
        }
    }
}
