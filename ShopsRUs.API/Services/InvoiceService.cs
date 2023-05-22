using ShopsRUs.API.Factories;
using ShopsRUs.API.Models;

namespace ShopsRUs.API.Services
{
    /// <summary>
    /// Invoice service
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly IDiscountFactory _discountFactory;

        public InvoiceService(IDiscountFactory discountFactory)
        {
            _discountFactory = discountFactory;
        }

        /// <summary>
        /// Gets discounted invoice amount
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public decimal GetDiscountedInvoiceAmount(Invoice invoice)
        {
            var discounts =  _discountFactory.GetApplicableDiscounts(invoice.Customer);

            var totalCost = invoice.InvoiceItems.Sum(x => x.Cost);
            var totalDiscount = discounts.Sum(x => x.Calculate(invoice.InvoiceItems));

            return totalCost - totalDiscount;
        }
    }
}
