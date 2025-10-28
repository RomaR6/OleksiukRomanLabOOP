using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace lab4C_
{
    public class ProductService
    {
        private List<Product> _productList = new List<Product>();

        public event Action ProductListChanged;

        protected virtual void OnProductListChanged()
        {
            ProductListChanged?.Invoke();
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _productList.AsReadOnly();
        }

        public Product GetProductByArticle(string article)
        {
            return _productList.FirstOrDefault(p => p.Article == article);
        }

        public void AddProduct(Product product)
        {
            if (_productList.Any(p => p.Article == product.Article))
            {
                throw new InvalidOperationException($"Продукт з артикулом {product.Article} вже існує.");
            }
            _productList.Add(product);
            OnProductListChanged();
        }

        public bool DeleteProduct(string article)
        {
            int removedCount = _productList.RemoveAll(p => p.Article.Equals(article, StringComparison.OrdinalIgnoreCase));
            if (removedCount > 0)
            {
                OnProductListChanged();
                return true;
            }
            return false;
        }

        public List<Product> SearchProducts(string article, string name)
        {
            return _productList.Where(p =>
                (string.IsNullOrWhiteSpace(article) || p.Article.StartsWith(article, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(name) || p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public void NotifyUpdate()
        {
            OnProductListChanged();
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Product p in _productList)
                {
                    sw.WriteLine(p.ToCsvString());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            _productList.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split(';');
                    if (parts.Length < 6) continue;

                    string type = parts[0];
                    string article = parts[1];
                    string name = parts[2];
                    string brand = parts[3];
                    double price = double.Parse(parts[4], CultureInfo.InvariantCulture);
                    int year = int.Parse(parts[5]);

                    Product p = null;

                    if (type == "Boiler" && parts.Length >= 8)
                    {
                        p = new Boiler(article, name, brand, price, year, int.Parse(parts[6]), int.Parse(parts[7]));
                    }
                    else if (type == "Siphon" && parts.Length >= 7)
                    {
                        p = new Siphon(article, name, brand, price, year, parts[6]);
                    }
                    else if (type == "Sink" && parts.Length >= 7)
                    {
                        p = new Sink(article, name, brand, price, year, parts[6]);
                    }

                    if (p != null) _productList.Add(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка завантаження рядка: {line}. Помилка: {ex.Message}");
                }
            }
            OnProductListChanged();
        }
    }
}