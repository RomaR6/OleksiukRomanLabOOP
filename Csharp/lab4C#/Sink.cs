namespace lab4C_
{
    public class Sink : Product
    {
        public string Material { get; set; }

        public Sink(string article, string name, string brand, double price, int year, string material)
            : base(article, name, brand, price, year)
        {
            Material = material;
        }

        public override string GetSpecificInfo()
        {
            return $"Матеріал: {Material}";
        }
    }
}