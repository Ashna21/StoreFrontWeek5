using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFData.data
{
    public class InventoryRespository
    {
        StoreFrontEntities1 db = new StoreFrontEntities1();

        //searchProducts
        public Product SearchProducts(string searchString)
        {
            Product foundProduct = db.Products.Where(x => x.ProductName.Contains(searchString) || x.Description.Contains(searchString)).FirstOrDefault();
            if (foundProduct != null)
            {
                return foundProduct;
            }
            else
                return null;
        }

        public Product GetProduct(int id)
        {
            Product product = db.Products.Where(x => x.ProductID.Equals(id)).FirstOrDefault();
            if (product != null)
                return product;
            else
                return null;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public void updateProduct(Product updatedProduct, int oldProductId, string path)
        {
            if (updatedProduct != null)
            {
                Product oldProduct = GetProduct(oldProductId);
                oldProduct.ProductName = updatedProduct.ProductName;
                oldProduct.Description = updatedProduct.Description;
                oldProduct.Price = updatedProduct.Price;
                oldProduct.ImageFile = path;
                db.SaveChanges();
            }
            
        }

    }
}
