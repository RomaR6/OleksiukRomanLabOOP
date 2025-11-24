using MyLibrary;

namespace lab6C_
{
    
    public abstract partial class Product : IProduct
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public Manufacturer Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public Product(string article, string name, Manufacturer brand, double price, int year)
        {
            Article = article;
            Name = name;
            Brand = brand;
            Price = price;
            Year = year;

          
            OnProductCreated();
        }

        
        partial void OnProductCreated();
    }
}