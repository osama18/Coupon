using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vouchers.DAL.DbContext;
using Vouchers.DAL.Repostiories;

namespace Vouchers.DAL
{
    public static class Registration
    {
        public static IServiceCollection RegisterDal(this IServiceCollection collection)
        {
            collection.AddTransient<IVouchersDbContext, VouchersDbContext>();
            collection.AddTransient<IProductRepository, ProductRepository>();
            collection.AddTransient<IDealRepository, DealRepository>(); 
            collection.AddScoped<IVoucherRepository, VoucherRepository>();

            var migrateConnectionString = Environment.GetEnvironmentVariable("VouchersConnectionString");
            collection.AddDbContext<VouchersDbContext>(options =>
                    options.UseSqlServer(migrateConnectionString));

            return collection;
        }
    }
}
