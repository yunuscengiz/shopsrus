using ShopsRUs.API.Models;

namespace ShopsRUs.API.Services
{
    /// <summary>
    /// Invoice service interface
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// Gets discounted invoice amount
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        decimal GetDiscountedInvoiceAmount(Invoice invoice);
    }
}
