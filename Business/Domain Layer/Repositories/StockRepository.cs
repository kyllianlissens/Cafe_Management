using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain_Layer.Repositories
{
    class StockRepository : Repository<Stock>
    {
        internal override void AddItem(Stock entity)
        {
            Items.Add(entity);
        }

        internal override Stock GetItem(int id)
        {
            return Items.Find(entity => entity.Id == id);
        }

        internal override List<Stock> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            var entity = GetItem(id);
            Items.Remove(entity);
            //TODO Persistence.Controller.RemoveProduct();
        }

        internal override void Load(List<Stock> list)
        {
            Items = list ?? new List<Stock>();
        }

        internal override Stock UpdateItem(Stock entity)
        {
            var toUpdate = GetItem(entity.Id);
            toUpdate.Description = entity.Description;

            toUpdate.products = entity.products;
            toUpdate.packages = entity.packages;
            //TODO SALES
            toUpdate.purchases = entity.purchases;
            
            //TODO Persistence.Controller.UpdateItem();
            return GetItem(entity.Id);
        }
    }
}
