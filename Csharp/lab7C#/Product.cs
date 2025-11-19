
using lab6C_;

namespace lab6C_
{
    public abstract class Product : IProduct
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
        }

        public virtual string GetFullInfo()
        {
            return $"Артикул: {Article}, Назва: {Name}, Бренд: {Brand.Name}, Ціна: {Price:F2} грн, Рік: {Year}";
        }

        public abstract string GetSpecificInfo();

        public static Product operator +(Product p, double value)
        {
            p.Price += value;
            return p;
        }
        public static Product operator -(Product p, double value)
        {
            p.Price = (p.Price - value > 0) ? p.Price - value : 0;
            return p;
        }
        public static Product operator *(Product p, double value)
        {
            p.Price *= value;
            return p;
        }
        public static Product operator /(Product p, double value)
        {
            if (value != 0) p.Price /= value;
            return p;
        }
    }
}