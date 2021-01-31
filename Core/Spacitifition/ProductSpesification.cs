using Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Spacitifition
{
    public class ProductSpesification:BaseISpecifition<Product>
    {
        public ProductSpesification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        public ProductSpesification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
