using SmartShop.Inventory;
using SmartShop.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartShop.Web.Controllers
{
    public class ProductListController : ApiController
    {
        // GET: api/ProductList
        public IEnumerable<Product> Get()
        {
            var data=new ProductManagementService().GetProductList();
            return data;
        }

        // GET: api/ProductList/5
        public Product Get(Guid? id)
        {
            if (id.HasValue)
            {
                var data = new ProductManagementService().GetProductDetails(id.Value);
                return data;
            }
            else
            {
                return null;
            }
            
        }

        // POST: api/ProductList
        public void Post([FromBody]ProductModel model)
        {
            model.AddProduct();
        }

        // PUT: api/ProductList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductList/5
        public void Delete(Guid? id)
        {
            new ProductModel().DeleteProduct(id.Value);
        }
    }
}
