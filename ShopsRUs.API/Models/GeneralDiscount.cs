namespace ShopsRUs.API.Models
{
    public class GeneralDiscount : IDiscount
    {
        /// <summary>
        /// Calculates the general discount for the collection
        /// </summary>
        /// <param name="invoiceItems"></param>
        /// <returns></returns>
        public decimal Calculate(List<InvoiceItem> invoiceItems)
        {
            var invoiceTotal = invoiceItems.Sum(x => x.Cost);

            return invoiceTotal >= 100 ? Math.Floor(invoiceTotal / 100) * 5 : 0;
        }
    }
}
