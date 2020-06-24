using System;
using System.Collections.Generic;
using Business.Domain_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            var stock = new Stock("Cafe nr1");

            var purchaseProducts = new List<Product>();
            var purchasePackages = new List<Package>();
            var p1 = new Product(1.95, "Bier", 1.5);
            purchasePackages.Add(new Package(p1, 20));


            purchaseProducts.Add(new Product(3, "Fles wijn", 2));
            
            
            var purchase1 = new Purchase("Initial purchase", DateTime.Now, purchaseProducts, purchasePackages);
            stock.HandlePurchase(purchase1);

            Assert.AreEqual(1, stock.packages.Count);
        }
    }
}
