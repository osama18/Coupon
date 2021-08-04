using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using Vouchers.DAL;
using Vouchers.DAL.DbContext;
using Vouchers.DAL.Repostiories;
using Xunit;

namespace Vouchers.Test
{
    public class VoucherRepositoryTests
    {
        private readonly Mock<IDealRepository> dealRepositoryMock;
        private readonly Mock<IProductRepository> productRepositoryMock;
        private readonly Mock<IVouchersDbContext> vouchersDbContextMock;
        private readonly VoucherRepository objectUnderTest;
        public VoucherRepositoryTests()
        {
            dealRepositoryMock = new Mock<IDealRepository>();
            productRepositoryMock = new Mock<IProductRepository>();
            vouchersDbContextMock = new Mock<IVouchersDbContext>();
            objectUnderTest = new VoucherRepository(vouchersDbContextMock.Object,
                dealRepositoryMock.Object,
                productRepositoryMock.Object);

        }

        [Fact]
        public async Task Test()
        {
        //    objectUnderTest.GetCheapest
        }
    }
}
