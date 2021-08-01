

using System;
using System.Collections.Generic;
using System.Linq;
using Vouchers.DAL.Entities;

namespace Vouchers.LegacyModel
{
    public class VoucherLegacy 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductCodes { get; set; }

        public IEnumerable<Product> ProductList => ProductCodes?.Split(',').Select(s => new Product { Code = s});
    }
}