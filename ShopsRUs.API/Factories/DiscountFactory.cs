using ShopsRUs.API.Models;
using ShopsRUs.API.Models.Enums;

namespace ShopsRUs.API.Factories
{
    /// <summary>
    /// Represents the discount factory
    /// </summary>
    public class DiscountFactory : IDiscountFactory
    {
        ///// <summary>
        ///// Calculates the final invoice amount after all discounts
        ///// </summary>
        ///// <param name="customer"></param>
        ///// <param name="invoiceItems"></param>
        ///// <returns></returns>
        //public decimal GetDiscountedInvoiceTotal(Customer customer, List<InvoiceItem> invoiceItems)
        //{
        //    var invoiceTotal = invoiceItems.Sum(x => x.Cost);

        //    //Calculate direct discount for every $100 on the bill
        //    var directDiscount = invoiceTotal >= 100 ? Math.Floor(invoiceTotal / 100) * 5 : 0;

        //    //Calculate percentage discount based on customer type
        //    var discountPercentage = customer.Type switch
        //    {
        //        CustomerType.Employee => 0.3m,
        //        CustomerType.Affiliate => 0.1m,
        //        _ => (DateTime.Now - customer.RegistrationDate).TotalDays > 730 ? 0.05m : 0
        //    };

        //    var percentageDiscountsTotal = invoiceItems
        //        .Where(x => x.Type != InvoiceItemType.Grocery)
        //        .Sum(x => x.Cost) * discountPercentage;

        //    //Apply disounts
        //    return invoiceTotal - percentageDiscountsTotal - directDiscount;
        //}

        /// <summary>
        /// Gets all applicable discounts
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<IDiscount> GetApplicableDiscounts(Customer customer)
        {
            List<IDiscount> discounts = new()
            {
                new GeneralDiscount()
            };

            if(customer.Type == CustomerType.Standard && (DateTime.Now - customer.RegistrationDate).TotalDays < 730)
                return discounts;

            var discountPercentage = customer.Type switch
            {
                CustomerType.Employee => 0.3m,
                CustomerType.Affiliate => 0.1m,
                _ => 0.05m
            };

            discounts.Add(new NonGroceryDiscount(discountPercentage));

            return discounts;
        }
    }
}
