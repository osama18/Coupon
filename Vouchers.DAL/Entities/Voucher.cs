
using System.Collections.Generic;
using System.Linq;

namespace Vouchers.DAL.Entities
{
    public class Voucher : Entity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public ICollection<ProductCode> ProductCodes { get; set; }

        public string ProductCodesstring => ProductCodes?.Aggregate("", (current, next) => current + ", " + next);
    }
}