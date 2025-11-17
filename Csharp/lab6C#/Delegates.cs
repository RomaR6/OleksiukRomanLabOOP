using System;
using System.Collections.Generic;

namespace lab6C_
{
    

    // 1
    public delegate bool ProductFilter(Product product);
    // 2
    public delegate double DiscountRule(Product product);
    // 3
    public delegate int ComparisonRule(Product p1, Product p2);


    public static class PredefinedRules
    {
        

        // 1
        public static ProductFilter ExpensiveFilter { get; }

        // 2
        public static Dictionary<string, DiscountRule> GetDiscountRules()
        {
            return new Dictionary<string, DiscountRule>
            {
                { "Знижка 10% на все", ApplyDiscount_10_Percent_All },
                { "Знижка 15% на Бойлери", ApplyDiscount_15_Percent_Boilers },
                { "Знижка 5% на Мийки", ApplyDiscount_5_Percent_Sinks }
            };
        }

        // 3
        public static ComparisonRule SortByPriceDesc { get; }


        
        static PredefinedRules()
        {
            ExpensiveFilter = FilterForExpensive;
            

            SortByPriceDesc = SortProductsByPriceDescending;
        }


        

        // 1
        private static bool FilterForExpensive(Product p)
        {
            if (p.Price > 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 2
        private static double ApplyDiscount_10_Percent_All(Product p)
        {
            return p.Price * 0.90;
        }

        
        private static double ApplyDiscount_15_Percent_Boilers(Product p)
        {
            if (p is Boiler)
            {
                return p.Price * 0.85;
            }
            else
            {
                return p.Price;
            }
        }

        
        private static double ApplyDiscount_5_Percent_Sinks(Product p)
        {
            if (p is Sink)
            {
                return p.Price * 0.95;
            }
            else
            {
                return p.Price;
            }
        }


        // 3
        private static int SortProductsByPriceDescending(Product p1, Product p2)
        {
            return p2.Price.CompareTo(p1.Price);
        }
    }
}