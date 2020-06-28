using System.Collections.Generic;

namespace Business.Domain_Layer.Entities
{
    public class Cafe : Entity
    {
        public List<Stock> Stocks = new List<Stock>();

        internal Cafe(int id, string description) : base(id)
        {
            Description = description;
            Stocks = new List<Stock>();
        }

        public string Description { get; set; }
    }
}