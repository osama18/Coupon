
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vouchers.DAL.Entities
{
    public class Deal : Entity
    {
        public string Name { get; set; }

        public double Price { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Voucher> Vouchers { get; set; }
    }
}