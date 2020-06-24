using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain_Layer.Repositories
{
    internal class PackageRepository : Repository<Package>
    {
        internal override void AddItem(Package entity)
        {
            Items.Add(entity);
            //TODO Persistence.Controller.AddProduct();
        }

        internal override Package GetItem(int id)
        {
            return Items.Find(entity => entity.Id == id);
        }

        internal override List<Package> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            var entity = GetItem(id);
            Items.Remove(entity);
            //TODO Persistence.Controller.RemoveProduct();
        }

        internal override void Load(List<Package> list)
        {
            Items = list ?? new List<Package>();
        }

        internal override Package UpdateItem(Package entity)
        {
            var toUpdate = GetItem(entity.Id);
            toUpdate.Product = entity.Product;
            toUpdate.Amount = entity.Amount;
           
            //TODO Persistence.Controller.UpdateItem();
            return GetItem(entity.Id);
        }
    }
}
