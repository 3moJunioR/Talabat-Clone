using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithBrandAndCategorySpecifications :BaseSpecifications<Product>
    {
        // This ctor 'll be used for creating an object that 'll be used to get all Prods
        public ProductWithBrandAndCategorySpecifications()
            :base()
        {
            Includes.Add(P=>P.Brand);
            Includes.Add(P => P.Category);
        }
        // This ctor 'll be used for creating an object that 'll be used to get specific Prod with id
        public ProductWithBrandAndCategorySpecifications(int id)
            :base(P=> P.Id==id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Category);
        }
    }
}
