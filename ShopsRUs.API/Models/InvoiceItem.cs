using ShopsRUs.API.Models.Enums;

namespace ShopsRUs.API.Models
{
    public class InvoiceItem
    {
        public InvoiceItemType Type { get; set; }
        public decimal Cost { get; set; }
    }
}
