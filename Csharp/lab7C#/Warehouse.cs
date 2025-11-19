
using lab6C_;
using System; 
using System.Collections.Generic;

namespace lab6C_
{
    public class Warehouse
    {
        public string Name { get; private set; }
        private List<Product> referencedItems;

        
        
        public event EventHandler WarehouseChanged;

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
                
                
                WarehouseChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void RemoveItemReference(Product product)
        {
            if (product != null)
            {
                
                if (referencedItems.Remove(product))
                {
                    
                    WarehouseChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void ClearReferences()
        {
            if (referencedItems.Count > 0)
            {
                referencedItems.Clear();
                
                WarehouseChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool ContainsItem(Product product)
        {
            return referencedItems.Contains(product);
        }

        
        public int GetItemCount()
        {
            return referencedItems.Count;
        }
    }
}