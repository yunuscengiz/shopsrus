namespace ShopsRUs.UnitTests
{
    public class GeneralDiscountTest
    {
        public static IEnumerable<object[]> TestDiscountCalculationData()
        {
            List<object[]> inputs = new()
            {
                new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 20, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 1, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 10, Type= InvoiceItemType.Grocery }
                },
                0m
            },

                new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 80, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 800, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 100, Type= InvoiceItemType.Grocery }
                },
                45m
            },

                new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = -1, Type= InvoiceItemType.Other }
                },
                0m
            }
            };

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestDiscountCalculationData))]
        public void TestDiscountCalculation(List<InvoiceItem> invoiceItems, decimal expected)
        {
            //Arrange
            decimal actual;

            IDiscount generalDiscount = new GeneralDiscount();

            //Act
            actual = generalDiscount.Calculate(invoiceItems);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
