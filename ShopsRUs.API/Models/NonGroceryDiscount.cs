using ShopsRUs.API.Models.Enums;

namespace ShopsRUs.API.Models
{
    public class NonGroceryDiscount : IDiscount
    {
        private readonly decimal discountPercentage = 0m;

        public NonGroceryDiscount(decimal discountPercentage)
        {
            this.discountPercentage = discountPercentage;
        }

        /// <summary>
        /// Calculates the total discount for non grocery items in the collection
        /// </summary>
        /// <param name="invoiceItems"></param>
        /// <returns></returns>
        public decimal Calculate(List<InvoiceItem> invoiceItems)
        {
            return invoiceItems.Where(x => x.Type != InvoiceItemType.Grocery).Sum(x => x.Cost) * discountPercentage;
        }
    }
}
