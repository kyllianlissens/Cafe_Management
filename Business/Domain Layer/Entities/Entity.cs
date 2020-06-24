using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain_Layer.Entities
{
    public class Entity
    {
        internal Entity(int id)
        {
            Id = id;
        }

        public int Id { get; internal set; }
    }
}
