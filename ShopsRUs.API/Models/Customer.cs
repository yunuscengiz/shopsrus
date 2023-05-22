using ShopsRUs.API.Models.Enums;

namespace ShopsRUs.API.Models
{
    public class Customer
    {
        public CustomerType Type { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
