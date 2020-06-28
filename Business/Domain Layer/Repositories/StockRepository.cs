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
            throw new NotImplementedException();
        }

        internal override Stock GetItem(int id)
        {
            throw new NotImplementedException();
        }

        internal override List<Stock> GetAll()
        {
            throw new NotImplementedException();
        }

        internal override void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        internal override void Load(List<Stock> list)
        {
            throw new NotImplementedException();
        }

        internal override Stock UpdateItem(Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
