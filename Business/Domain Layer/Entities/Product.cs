using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer
{
    public class Product : Entity
    {
        public Product(int id, double salePrice, string description, double purchasePrice, Stock stock) : base(id)
        {
            SalePrice = salePrice;
            Description = description;
            PurchasePrice = purchasePrice;
            Stock = stock;
        }

        public Stock Stock { get; set; }
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
    }
}