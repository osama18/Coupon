using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominos.OLO.Vouchers.SwaggerExamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Vouchers.Business.ApplicationServices;
using Vouchers.Business.Models;
using Vouchers.Common.Logging;

namespace Vouchers.Web.Controllers
{
    [ApiController]
    [Route("voucher/")]
    public class VoucherController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IVoucherServices voucherServices;

        public VoucherController(ILogger logger, IVoucherServices voucherServices)
        {
            this.logger          = logger;
            this.voucherServices = voucherServices;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ICollection<VoucherDTO>>> Get([FromQuery] int count = 1000)
        {
            try
            {
                var result = await voucherServices.GetAll(count);
                return Ok(result);
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
        [Route("getbyid/{id}")]
        public async Task<ActionResult<VoucherDTO>> GetVoucherById([FromRoute] Guid id)
        {
            try
            {
                var voucher = await voucherServices.Get(id);

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
        [Route("getbyname/{name}")]
        public async Task<ActionResult<ICollection<VoucherDTO>>> GetVouchersByName([FromRoute] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return NotFound();
                }

                var vouchers = await voucherServices.Get(name);

                return Ok(vouchers);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetVouchersByName.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<ICollection<VoucherDTO>>> GetVouchersByNameSearch([FromQuery] string searchTerm, [FromQuery] int take, [FromQuery] int skip = 0)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return NotFound();
                }

                var vouchers = await voucherServices.Search(searchTerm,take,skip);

                return Ok(vouchers);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetVouchersByNameSearch.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("getcheapest/{code}")]
        public async Task<ActionResult<VoucherDTO>> GetCheapestVoucherByProductCode([FromRoute] string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return NotFound();
                }

                var vouchers = await voucherServices.GetCheapest(code);

                return Ok(vouchers);
            }
            catch (Exception ex)
            {
                await logger.LogErrorAsync(ErrorLevel.Major, ex, LogEvent.GetCheapestVoucherByProductCode.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }      
    }
}