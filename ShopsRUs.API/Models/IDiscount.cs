namespace ShopsRUs.API.Models
{
    public interface IDiscount
    {
        /// <summary>
        /// Calculates the total discount for the collection
        /// </summary>
        /// <param name="invoiceItems"></param>
        /// <returns></returns>
        decimal Calculate(List<InvoiceItem> invoiceItems);
    }
}
