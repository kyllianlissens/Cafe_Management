using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer
{
    public class Stock : Entity
    {
        public List<Product> products = new List<Product>();
        public List<Package> packages = new List<Package>();

        public List<Purchase> purchases = new List<Purchase>(); //List of purchases linked to stock.

        public string Description;
        public Stock(int id, string description) : base(id)
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
