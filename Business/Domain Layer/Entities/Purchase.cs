using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Entities;

namespace Business.Domain_Layer
{
    public class Purchase : Entity
    {
        public Purchase(int id, string description, DateTime date, List<Product> products, List<Package> packages) : base(id)
        {
            Description = description;
            Date = date;
            Products = products;
            Packages = packages;
        }

        public DateTime Date { get; set; }
        public List<Product> Products { get; set; }
        public List<Package> Packages { get; set; }
        public string Description { get; set; }

    }
}
