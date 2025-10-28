using System;

namespace lab4C_
{
    public class Boiler : Product
    {
        private int _volumeLiters;
        private int _powerW;

        public int VolumeLiters
        {
            get => _volumeLiters;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(VolumeLiters), "Об'єм має бути додатнім числом.");
                _volumeLiters = value;
            }
        }

        public int PowerW
        {
            get => _powerW;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(PowerW), "Потужність має бути додатнім числом.");
                _powerW = value;
            }
        }

        public Boiler(string article, string name, string brand, double price, int year, int volume, int power)
            : base(article, name, brand, price, year)
        {
            VolumeLiters = volume;
            PowerW = power;
        }

        public override string GetSpecificInfo()
        {
            return $"Об'єм: {VolumeLiters} л, Потужність: {PowerW} Вт";
        }
        public override string ToCsvString()
        {
            return base.ToCsvString() + $";{VolumeLiters};{PowerW}";
        }
    }
}