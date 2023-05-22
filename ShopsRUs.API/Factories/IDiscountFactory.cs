using ShopsRUs.API.Models;

namespace ShopsRUs.API.Factories
{
    /// <summary>
    /// Represents the interface of the discount factory
    /// </summary>
    public interface IDiscountFactory
    {
        ///// <summary>
        ///// Calculates the final invoice amount after all discounts
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <param name="invoiceItems"></param>
        ///// <returns></returns>
        //decimal GetDiscountedInvoiceTotal(Customer customer, List<InvoiceItem> invoiceItems);

        /// <summary>
        /// Gets all applicable discounts
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        List<IDiscount> GetApplicableDiscounts(Customer customer);
    }
}
