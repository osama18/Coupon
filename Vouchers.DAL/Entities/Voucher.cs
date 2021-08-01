
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vouchers.DAL.Entities
{
    public class Voucher : Entity
    {
        public Deal Deal { get; set; }
        public long DealId { get; set; }
        public Guid ExternalId { get; set; }
    }
}