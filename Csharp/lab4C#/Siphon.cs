using System;

namespace lab4C_
{
    public class Siphon : Product
    {
        private string _siphonType;
        public string SiphonType
        {
            get => _siphonType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип сифона не може бути порожнім.");
                _siphonType = value;
            }
        }

        public Siphon(string article, string name, string brand, double price, int year, string type)
            : base(article, name, brand, price, year)
        {
            SiphonType = type;
        }

        public override string GetSpecificInfo()
        {
            return $"Тип сифона: {SiphonType}";
        }

        public override string ToCsvString()
        {
            return base.ToCsvString() + $";{SiphonType}";
        }
    }
}