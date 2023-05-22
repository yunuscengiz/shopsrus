namespace ShopsRUs.API.Models
{
    public class Invoice
    {
        public Invoice()
        {
            Customer = new Customer();
            InvoiceItems = new List<InvoiceItem>();
        }

        public Customer Customer { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
