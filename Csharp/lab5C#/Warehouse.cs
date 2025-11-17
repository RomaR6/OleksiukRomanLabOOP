using System.Collections.Generic;
namespace lab5C_
{
    public class Warehouse
    {
        public string Name { get; private set; }
        private List<Product> referencedItems;

        public Warehouse(string name)
        {
            Name = name;
            referencedItems = new List<Product>();
        }

        public void AddItemReference(Product product)
        {
            if (product != null && !referencedItems.Contains(product))
            {
                referencedItems.Add(product);
            }
        }

        public void RemoveItemReference(Product product)
        {
            if (product != null)
            {
                referencedItems.Remove(product);
            }
        }

        public void ClearReferences()
        {
            referencedItems.Clear();
        }

        public bool ContainsItem(Product product)
        {
            return referencedItems.Contains(product);
        }
    }
}