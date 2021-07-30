using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using System;


namespace Vouchers.DAL.DbContext
{
    
    public class VouchersDbContextFactory : IDesignTimeDbContextFactory<VouchersDbContext>
    {
        public VouchersDbContext CreateDbContext(string[] args)
        {
            var migrateConnectionString = Environment.GetEnvironmentVariable("VouchersConnectionString");
            if (string.IsNullOrWhiteSpace(migrateConnectionString))
            {
                throw new Exception("Vouchers environment variable does not contain any connectionstring.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<VouchersDbContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(migrateConnectionString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName));
            return new VouchersDbContext(optionsBuilder.Options);
        }

    }
}
