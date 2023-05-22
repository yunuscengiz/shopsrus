namespace ShopsRUs.UnitTests
{
    public class IntegrationTest
    {
        public static IEnumerable<object[]> TestGetDiscountedInvoiceAmountData()
        {
            List<object[]> inputs = new()
            {
                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Employee,RegistrationDate = DateTime.Now },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 5, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 15, Type= InvoiceItemType.Grocery }
                    }
                },
                27m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Affiliate,RegistrationDate = DateTime.Now },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 5, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Grocery }
                    }
                },
                100m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Standard,RegistrationDate = new DateTime(2015, 1, 11) },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other }
                    }
                },
                103.50m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Standard,RegistrationDate = DateTime.Now.AddDays(-500) },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other }
                    }
                },
                109m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Employee,RegistrationDate = DateTime.Now.AddDays(-500) },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 100, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other }
                    }
                },
                76m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Employee,RegistrationDate = new DateTime(2010, 1, 11) },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 4, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 4, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 20, Type= InvoiceItemType.Grocery }
                    }
                },
                26.8m
                },

                new object[] {
                new Invoice
                {
                    Customer = new Customer { Type= CustomerType.Standard,RegistrationDate = DateTime.Now.AddDays(-1) },
                    InvoiceItems = new List<InvoiceItem>  {
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other },
                        new InvoiceItem { Cost = 10, Type= InvoiceItemType.Grocery },
                        new InvoiceItem { Cost = 20, Type= InvoiceItemType.Other }
                    }
                },
                40m
                }
            };

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestGetDiscountedInvoiceAmountData))]
        public void TestGetDiscountedInvoiceAmount(Invoice invoice, decimal expected)
        {
            //Arrange
            decimal actual;

            IDiscountFactory factory = new DiscountFactory();
            IInvoiceService invoiceService = new InvoiceService(factory);
            InvoiceController invoiceController = new(invoiceService);

            //Act
            actual = invoiceController.GetDiscountedInvoiceAmount(invoice);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}