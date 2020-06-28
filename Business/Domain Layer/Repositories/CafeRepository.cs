using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer.Repositories
{
    internal class CafeRepository : Repository<Cafe>
    {
        internal override void AddItem(Cafe entity)
        {
            Items.Add(entity);
        }

        internal override Cafe GetItem(int id)
        {
            return Items.Find(entity => entity.Id == id);
        }

        internal override List<Cafe> GetAll()
        {
            return Items;
        }

        internal override void RemoveItem(int id)
        {
            var entity = GetItem(id);
            Items.Remove(entity);
        }

        internal override void Load(List<Cafe> list)
        {
            Items = list ?? new List<Cafe>();
        }

        internal override Cafe UpdateItem(Cafe entity)
        {
            var toUpdate = GetItem(entity.Id);
            toUpdate.Description = entity.Description;
            return GetItem(entity.Id);
        }
    }
}
