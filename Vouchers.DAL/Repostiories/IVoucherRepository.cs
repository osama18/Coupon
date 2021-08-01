using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.DAL.Entities;

namespace Vouchers.DAL.Repostiories
{
    public interface IVoucherRepository : IGenericRepository<Voucher>
    {
        Task<Voucher> RetrieveByExternalId(Guid id);
        Task<ICollection<Voucher>> RetrieveByName(string name);
        Task<ICollection<Voucher>> SearchByName(string name, int take, int skip = 0);
        Task<ICollection<Voucher>> RetrievePageIncludeProducts(int take, int skip);
        Task<Voucher> GetCheapest(string productCode);
    }
}