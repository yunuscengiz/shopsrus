namespace ShopsRUs.UnitTests
{
    public class NonGroceryDiscountTest
    {
        public static IEnumerable<object[]> TestDiscountCalculationData()
        {
            List<object[]> inputs = new()
            {
                new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 10, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 90, Type= InvoiceItemType.Other },
                    new InvoiceItem { Cost = 1, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 2, Type= InvoiceItemType.Grocery }
                },
                0.1m,
                10m
            },

                new object[] {
                new List<InvoiceItem>
                {
                    new InvoiceItem { Cost = 1, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 2, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 3, Type= InvoiceItemType.Grocery },
                    new InvoiceItem { Cost = 4, Type= InvoiceItemType.Grocery }
                },
                0.3m,
                0m
            }
            };

            return inputs;
        }

        [Theory]
        [MemberData(nameof(TestDiscountCalculationData))]
        public void TestDiscountCalculation(List<InvoiceItem> invoiceItems, decimal percentage, decimal expected)
        {
            //Arrange
            decimal actual;

            IDiscount nonGroceryDiscount = new NonGroceryDiscount(percentage);

            //Act
            actual = nonGroceryDiscount.Calculate(invoiceItems);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
