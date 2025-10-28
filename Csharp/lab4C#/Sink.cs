using System;

namespace lab4C_
{
    public class Sink : Product
    {
        private string _material;
        public string Material
        {
            get => _material;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Матеріал не може бути порожнім.");
                _material = value;
            }
        }
        public Sink(string article, string name, string brand, double price, int year, string material)
            : base(article, name, brand, price, year)
        {
            Material = material;
        }

        public override string GetSpecificInfo()
        {
            return $"Матеріал: {Material}";
        }

        public override string ToCsvString()
        {
            return base.ToCsvString() + $";{Material}";
        }
    }
}