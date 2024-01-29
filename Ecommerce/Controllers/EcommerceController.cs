using Ecommerce.Requests;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EcommerceController : ControllerBase
    {
        private readonly IECommerceService _ecommerceService;
        public EcommerceController(IECommerceService ecommerceService)
        {
            _ecommerceService = ecommerceService;
        }

        [HttpPost("add-order")]
        public async Task<ActionResult> AddOrder([FromBody] AddOrderRequest request)
        {
            return Ok(await _ecommerceService.AddOrder(request));
        }

        [HttpPost("add-customer")]
        public async Task<ActionResult> AddCustomer([FromBody] AddCustomerRequest request)
        {
            return Ok(await _ecommerceService.AddCustomer(request));
        }

        [HttpPost("add-product")]
        public async Task<ActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return Ok(await _ecommerceService.AddProduct(request));
        }

        [HttpPost("report")]
        public async Task<ActionResult> Report(ReportingRequest request)
        {
            return Ok(await _ecommerceService.Report(request));
        }
    }
}
