namespace lab4C_
{
    public interface IProduct
    {
        string GetFullInfo();
        string GetSpecificInfo();
        string ToCsvString();
    }
}