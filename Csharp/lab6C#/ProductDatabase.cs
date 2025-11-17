
using lab6C_;
using System.Collections.Generic;
using System.Linq;

namespace lab6C_
{
    public static class ProductDatabase
    {
        private static List<Product> items = new List<Product>();

        public static void Add(Product product)
        {
            items.Add(product);
        }

        public static List<Product> GetItems()
        {
            return new List<Product>(items);
        }

        public static Product FindByArticle(string article)
        {
            return items.FirstOrDefault(p => p.Article.Equals(article, System.StringComparison.OrdinalIgnoreCase));
        }

        public static int RemoveAllByArticle(string article)
        {
            return items.RemoveAll(p => p.Article.Equals(article, System.StringComparison.OrdinalIgnoreCase));
        }

        public static void Clear()
        {
            items.Clear();
        }
    }
}