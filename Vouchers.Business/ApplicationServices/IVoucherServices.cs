using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.Business.Models;

namespace Vouchers.Business.ApplicationServices
{
    public interface IVoucherServices
    {
        Task<ICollection<Voucher>> GetAll(int count = 0);
        Task<Voucher> Get(System.Guid id);
        Task<ICollection<Voucher>> Get(string name);
        Task<ICollection<Voucher>> Search(string searchTerm);
        Task<Voucher> GetCheapest(string productCode);
    }
}