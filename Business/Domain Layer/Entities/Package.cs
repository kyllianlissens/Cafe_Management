using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer
{
    public class Package : Entity
    {
        public Package(int id, Product product, int amount) : base(id)
        {
            Product = product;
            Amount = amount;
        }

        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
