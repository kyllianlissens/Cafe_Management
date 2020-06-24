using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain_Layer
{
    public class Stock
    {
        public List<Product> products = new List<Product>();
        public List<Package> packages = new List<Package>();

        public List<Purchase> purchases = new List<Purchase>(); //List of purchases linked to stock.

        public readonly string Description;
        public Stock(string description)
        {
            Description = description;
        }


        public void HandlePurchase(Purchase purchase)
        { 
            purchases.Add(purchase); //Add to purchase log.
            packages.AddRange(purchase.Packages);
            products.AddRange(purchase.Products);
        }

        
    }
}
