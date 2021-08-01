
using System;
using System.Collections.Generic;

namespace Vouchers.DAL.Entities
{
    public class Product : Entity
    {
        public string Code { get; set; }
        public ICollection<Deal> Deals { get; set; }
    }
}