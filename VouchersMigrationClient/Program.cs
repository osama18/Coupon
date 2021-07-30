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
            var repo = serviceProvider.GetService<IVoucherRepository>();

            string dataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";
            var text = File.ReadAllText(dataFilename);
            var legacyList = JsonConvert.DeserializeObject<VoucherLegacy[]>(text).ToList();
            var vouchers = legacyList.Select(LegacyTraslator.VoucherLegacyToVoucher);

            foreach (var voucher in vouchers)
            {
                repo.InsertAsync(voucher).Wait();
                try
                {
                    repo.SaveAsync().Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to write voucher with Id {voucher.Id}");
                }
            }
            
        }
    }
}
