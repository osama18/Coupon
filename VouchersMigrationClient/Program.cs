using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;
using System.IO;
using Vouchers.Common;
using Vouchers.DAL;
using Vouchers.DAL.Entities;
using Vouchers.DAL.Repostiories;
using Vouchers.LegacyModel;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace VouchersMigrationClient
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            StartUp();

            RunSeeding();
        }

        private static void StartUp()
        {
            var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            //setup our DI
            var services = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IConfigurationRoot>(configuration)
                .RegisterCommon()
                .RegisterDal();

            services.RegisterAssemblyPublicNonGenericClasses(
                     Assembly.GetAssembly(typeof(Program)))
                .AsPublicImplementedInterfaces();

            serviceProvider = services.BuildServiceProvider();
        }

        static void RunSeeding()
        {
            SeedDeals();
            SeeVouchers();
        }

        private static void SeeVouchers()
        {
            var dealsRepo = serviceProvider.GetService<IDealRepository>();
            
        }

        private static void SeedDeals()
        {
            var dealsRepo = serviceProvider.GetService<IDealRepository>();
            var vouchersRepo = serviceProvider.GetService<IVoucherRepository>();
            var csvData = File.ReadAllLines("Vouchers.csv")
                    .Select(s => new
                    {
                        Name = s.Split('|')[0],
                        Price = s.Split('|')[1],
                        ProductCodes = s.Split('|')[2]
                    }).ToArray();

            var productDictionary = csvData.SelectMany(s => s.ProductCodes?.Split(',')).Distinct().Select(s => new Product { Code = s }).ToDictionary(x => x.Code); ;
            string dataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";
            var text = File.ReadAllText(dataFilename);
            var legacyList = JsonConvert.DeserializeObject<VoucherLegacy[]>(text).ToList();

            var deals = csvData.Select(s => new Deal
            {
                Name = s.Name,
                Price = double.Parse(s.Price),
                Products = s.ProductCodes.Split(',').Select(s => productDictionary[s]).ToList(),
                Vouchers = legacyList.Where(x => x.Name == s.Name).Select(r => new Voucher { ExternalId = r.Id}).ToList()
            });


            dealsRepo.InsertRangeAsync(deals).Wait();
            dealsRepo.SaveAsync().Wait();
        }
    }
}
