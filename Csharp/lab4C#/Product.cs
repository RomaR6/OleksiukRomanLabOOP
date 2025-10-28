using System;
using System.Globalization;
using System.Linq;

namespace lab4C_
{
    public abstract class Product : IProduct
    {
        private string _article;
        private string _name;
        private double _price;
        private int _year;

        public string Article
        {
            get => _article;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Артикул не може бути порожнім.");
                if (!value.All(char.IsDigit))
                    throw new ArgumentException("Артикул має складатися лише з цифр.");
                _article = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва не може бути порожньою.");
                _name = value;
            }
        }

        public string Brand { get; set; }

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Price), "Ціна не може бути негативною.");
                _price = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year + 1)
                    throw new ArgumentOutOfRangeException(nameof(Year), $"Рік має бути в діапазоні [1900-{DateTime.Now.Year + 1}].");
                _year = value;
            }
        }
        public Product(string article, string name, string brand, double price, int year)
        {
            Article = article;
            Name = name;
            Brand = brand;
            Price = price;
            Year = year;
        }

        public virtual string GetFullInfo()
        {
            return $"Артикул: {Article}, Назва: {Name}, Бренд: {Brand}, Ціна: {Price:F2} грн, Рік: {Year}";
        }

        public abstract string GetSpecificInfo();

        public virtual string ToCsvString()
        {
            return $"{GetType().Name};{Article};{Name};{Brand};{Price.ToString(CultureInfo.InvariantCulture)};{Year}";
        }
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
            if (value == 0)
                throw new DivideByZeroException("Ділення на нуль неможливе.");
            p.Price /= value;
            return p;
        }
    }
}