
using lab6C_;

namespace lab6C_
{
    public class Boiler : Product
    {
        public int VolumeLiters { get; set; }
        public int PowerW { get; set; }

        public Boiler(string article, string name, Manufacturer brand, double price, int year, int volume, int power)
            : base(article, name, brand, price, year)
        {
            VolumeLiters = volume;
            PowerW = power;
        }

        public override string GetSpecificInfo()
        {
            return $"Об'єм: {VolumeLiters} л, Потужність: {PowerW} Вт";
        }
    }
}