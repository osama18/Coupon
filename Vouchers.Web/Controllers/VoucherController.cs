using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Dominos.OLO.Vouchers.SwaggerExamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Vouchers.Common.Logging;

namespace Dominos.OLO.Vouchers.Controllers
{
    [ApiController]
    [Route("voucher/")]
    public class VoucherController : ControllerBase
    {
        private VoucherRepository _voucherRepository;
        private readonly ILogger logger;

        public VoucherController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ICollection<Voucher>>> Get(int count = 0)
        {
            try
            {
                var vouchers = Repository.GetVouchers();
                if (count == 0)
                {
                    count = vouchers.Length;
                }
                var returnVouchers = new List<Voucher>();
                for (var i = 0; i < count; i++)
                {
                    returnVouchers.Add(vouchers[i]);
                }
                return Ok(returnVouchers);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToGetVouchers.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///  Retrieve a voucher by id
        /// </summary>
        /// <param name="id"> The unique identifier of the voucher</param>
        /// <returns>Voucher Details</returns>
        /// <response code="200">Success: Voucher returned</response>
        /// <response code="404">The voucher was not found</response>
        /// <response code="500">Internal server error: the server was unable to process the request, due to a server error.</response>       
        [SwaggerResponseExample(200, typeof(VoucherExamples))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<Voucher>> GetVoucherById([FromRoute] Guid id)
        {
            try
            {
                var vouchers = Repository.GetVouchers();
                Voucher voucher = null;
                for (var i = 0; i < vouchers.Length; i++)
                {
                    if (vouchers[i].Id == id)
                    {
                        voucher = vouchers[i];
                    }
                }

                if (voucher == null)
                    return NotFound();

                return Ok(voucher);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.FailedToGetVoucher.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("get/{name}")]
        public async Task<ActionResult<ICollection<Voucher>>> GetVouchersByName([FromRoute] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return NotFound();
                }

                var vouchers = Repository.GetVouchers();
                var returnVouchers = new List<Voucher>();
                for (var i = 0; i < vouchers.Length; i++)
                {
                    if (vouchers[i].Name == name)
                    {
                        returnVouchers.Add(vouchers[i]);
                    }
                }

                return Ok(returnVouchers);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetVouchersByName.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<ICollection<Voucher>>> GetVouchersByNameSearch([FromQuery] string search)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(search))
                {
                    return NotFound();
                }

                var vouchers = Repository.GetVouchers();
                var returnVouchers = new List<Voucher>();
                for (var i = 0; i < vouchers.Length; i++)
                {
                    if (vouchers[i].Name == search)
                    {
                        returnVouchers.Add(vouchers[i]);
                    }
                }

                return Ok(search);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetVouchersByNameSearch.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("getcheapest/{productcode}")]
        public async Task<ActionResult<Voucher>> GetCheapestVoucherByProductCode([FromRoute] string productCode)
        {
            try
            {
                //Write implementation here;
                return Ok();
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetCheapestVoucherByProductCode.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        internal VoucherRepository Repository
        {
            get
            {
                return _voucherRepository ?? (_voucherRepository = new VoucherRepository());
            }
            set
            {
                _voucherRepository = value;
            }
        }
    }
}