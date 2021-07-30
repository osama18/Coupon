
using System;

namespace Vouchers.DAL.Entities
{
    public class ProductCode : Entity
    {
        public string Name { get; set; }
        public Voucher Voucher { get; set; }
        public Guid VoucherId { get; internal set; }
    }
}