﻿using CodeCoverageWorkshop.DAL.Models;
using System;
using System.Collections.Generic;

namespace CodeCoverageWorkshop.Logic
{
    public class DiscountProvider : IDiscountProvider
    {
        public double CalculateDiscount(User user, IList<Product> products, string promoCode)
        {
            var discount = 0.0;
            if (DateTime.UtcNow.Year - user.AccountActivationDate.Year > 1)
            {
                discount += 2.0;
            }

            return discount;
        }
    }

    public interface IDiscountProvider
    {
        double CalculateDiscount(User user, IList<Product> products, string promoCode);
    }
}
