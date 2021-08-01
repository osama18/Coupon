using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vouchers.Business.Models;

namespace Vouchers.Business.ApplicationServices
{
    public interface IVoucherServices
    {
        Task<ICollection<VoucherDTO>> GetAll(int take, int skip = 0);
        Task<VoucherDTO> Get(System.Guid id);
        Task<ICollection<VoucherDTO>> Get(string name);
        Task<ICollection<VoucherDTO>> Search(string searchTerm, int take, int skip = 0);
        Task<VoucherDTO> GetCheapest(string productCode);
    }
}