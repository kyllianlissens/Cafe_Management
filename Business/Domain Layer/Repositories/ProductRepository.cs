using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain_Layer.Repositories
{
    internal class ProductRepository : Repository<Product>
    {
        internal override void AddItem(Product entity)
        {
            Items.Add(entity);
            //TODO Persistence.Controller.AddProduct();
        }

        internal override Product GetItem(int id)
        {
            return Items.Find(entity => entity.Id == id);
        }

        internal override List<Product> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            var entity = GetItem(id);
            Items.Remove(entity);
            //TODO Persistence.Controller.RemoveProduct();
        }

        internal override void Load(List<Product> list)
        {
            Items = list ?? new List<Product>();
        }

        internal override Product UpdateItem(Product entity)
        {
            var toUpdate = GetItem(entity.Id);
            toUpdate.Description = entity.Description;
            toUpdate.PurchasePrice = entity.PurchasePrice;
            toUpdate.SalePrice = entity.SalePrice;
            //TODO Persistence.Controller.UpdateItem();
            return GetItem(entity.Id);
        }
    }
}
