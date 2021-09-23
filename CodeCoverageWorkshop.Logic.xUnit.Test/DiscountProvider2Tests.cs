using CodeCoverageWorkshop.DAL.Models;
using System.Collections.Generic;
using Xunit;

namespace CodeCoverageWorkshop.Logic.xUnit.Test
{
    public class DiscountProvider2Tests
    {
        [Fact]
        public void CalculateDiscount_ShouldApplyDiscount_ForSumOver100()
        {
            // Arrange
            var discountProvider2 = new DiscountProvider2();
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 41.0m });
            string promoCode = null;

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(95.95m, result);
        }

        [Fact]
        public void CalculateDiscount_ShouldApplyDiscountCode()
        {
            // Arrange
            var discountProvider2 = new DiscountProvider2();
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 41.0m });
            string promoCode = "HOLIDAYS10";

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(90.9m, result);
        }

        [Fact]
        public void CalculateDiscount_ShouldNotApplyDiscount_WhenDiscountCodeInvalid()
        {
            // Arrange
            var discountProvider2 = new DiscountProvider2();
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            string promoCode = "HOLIDAYS101";

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(90.0m, result);
        }
    }
}
