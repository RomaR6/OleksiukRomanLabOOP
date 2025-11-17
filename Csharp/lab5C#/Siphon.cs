using lab5C_;

namespace lab5C_
{
    public class Siphon : Product
    {
        public string SiphonType { get; set; }

        public Siphon(string article, string name, Manufacturer brand, double price, int year, string type)
            : base(article, name, brand, price, year)
        {
            SiphonType = type;
        }

        public override string GetSpecificInfo()
        {
            return $"Тип сифона: {SiphonType}";
        }
    }
}