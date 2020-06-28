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
        private static readonly PackageRepository packageRepository = new PackageRepository();


        public Controller()
        {
            if (_isLoaded)
            {
                /*
                 *  For each CAFE get ALL STOCKS.
                 *
                 *  For each stock get products & packages linked to them 
                 *  
                 *  + Get all purchases & sales linked to stock
                 *
                 *  foreach product check package_idpackage if not null make package of product
                 *
                 *
                 *  foreach product check purchase_idpurchase if not null 
                 *
                 */


                _isLoaded = true;
            }
        }


    }
}
