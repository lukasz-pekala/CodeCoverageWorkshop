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
            var products = CreateProductsWithSum101();
            string promoCode = null;

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(95.95m, result);
        }

        // #100%CoverageMyth FIX for Mutation: a change to "sum >= 100.0m" is not covered
        //[Fact]
        //public void CalculateDiscount_ShouldNOTApplyDiscount_ForSum100()
        //{
        //    // Arrange
        //    var discountProvider2 = new DiscountProvider2();
        //    var products = CreateProductsWithSum100();
        //    string promoCode = null;

        //    // Act
        //    var result = discountProvider2.CalculateDiscount(products, promoCode);

        //    // Assert
        //    Assert.Equal(100.0m, result);
        //}

        [Fact]
        public void CalculateDiscount_ShouldApplyDiscountCode()
        {
            // Arrange
            var discountProvider2 = new DiscountProvider2();
            var products = CreateProductsWithSum101();
            string promoCode = "HOLIDAYS10";

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(90.9m, result);
        }

        [Fact]
        public void CalculateDiscount_ShouldNotApplyDiscount_WhenDiscountCodeInvalidAndSumLessThan100()
        {
            // Arrange
            var discountProvider2 = new DiscountProvider2();
            var products = CreateProductsWithSum60();
            string promoCode = "HOLIDAYS101";

            // Act
            var result = discountProvider2.CalculateDiscount(products, promoCode);

            // Assert
            Assert.Equal(60.0m, result);
        }

        private IList<Product> CreateProductsWithSum100()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 40.0m });
            return products;
        }

        private IList<Product> CreateProductsWithSum101()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 41.0m });
            return products;
        }

        private IList<Product> CreateProductsWithSum60()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            products.Add(new Product() { Name = "Pencil", Price = 30.0m });
            return products;
        }
    }
}
