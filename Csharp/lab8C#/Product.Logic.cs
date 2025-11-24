using MyLibrary;

namespace lab6C_
{
 
    public abstract partial class Product
    {
       
        partial void OnProductCreated()
        {
           
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