using System;
using System.Collections.Generic;

namespace Vouchers.Business.Models
{
    public class VoucherDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}