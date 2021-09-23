using CodeCoverageWorkshop.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeCoverageWorkshop.Logic
{
    // This class has 100% code coverage but mutation score of 90 (calculated by stryker-dotnet)
    public class DiscountProvider2
    {
        public decimal CalculateDiscount(IList<Product> products, string promoCode)
        {
            var sum = products.Sum(x => x.Price);

            if (promoCode == "HOLIDAYS10")
                return sum - sum * 0.10m;

            if (sum > 100.0m) // Mutation: "sum > 100.0m" is not covered
                return sum - sum * 0.05m;

            return sum;
        }
    }
}
