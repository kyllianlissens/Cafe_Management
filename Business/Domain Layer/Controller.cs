using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain_Layer.Repositories;

namespace Business.Domain_Layer.Entities
{
    public class Controller
    {
        private readonly bool _isLoaded = false;

        private static readonly ProductRepository productRepository = new ProductRepository();


    }
}
