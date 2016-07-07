using StoreFront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Data
{
    public class InventoryRepository
    {
        StoreFrontDataEntities data = new StoreFrontDataEntities();

//SearchProducts
        public Data.Product1 SearchProducts (string searchString)
        {
            if (data.Product1.Any(x => x.ProductName.Contains(searchString) || x.Description.Contains(searchString)))
            {
                Data.Product1 foundProduct = data.Product1.Where(x => x.ProductName.Contains(searchString) || x.Description.Contains(searchString)).FirstOrDefault();
                return foundProduct;
            }
            else
                return null;
        }

//GetProduct 
        public Data.Product1 GetProduct(int id)
        {
            if (data.Product1.Any(x => x.ProductID.Equals(id)))
            {
                Data.Product1 product = data.Product1.Where(x => x.ProductID.Equals(id)).FirstOrDefault();
                return product;
            }
            else        
                return null;
        }
    }
}
