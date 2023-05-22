using Microsoft.AspNetCore.Mvc;
using ShopsRUs.API.Models;
using ShopsRUs.API.Services;

namespace ShopsRUs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("[action]")]
        public decimal GetDiscountedInvoiceAmount([FromBody()] Invoice invoice)
        {
            return _invoiceService.GetDiscountedInvoiceAmount(invoice);
        }
    }
}
