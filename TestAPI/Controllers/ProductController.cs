using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET api/product
        public IEnumerable<TestAPI.Models.product> Get()
        {
            ProductDataClassDataContext d = new ProductDataClassDataContext();
            return d.products;
        }
        // GET api/product/5
        public TestAPI.Models.product Get(int id)
        {
            ProductDataClassDataContext d = new ProductDataClassDataContext();
            var item = d.products.FirstOrDefault(i => i.productId == id);

            if (item != null)
            {
                return item;
            }
            return null;
        }

        public void Post([FromBody]TestAPI.Models.product value)
        {
            ProductDataClassDataContext OdContext = new ProductDataClassDataContext();
            TestAPI.Models.product objCourse = new TestAPI.Models.product();
            objCourse.productName = value.productName;
            objCourse.price = value.price;
            OdContext.products.InsertOnSubmit(objCourse);
            OdContext.SubmitChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]TestAPI.Models.product value)
        {
            ProductDataClassDataContext OdContext = new ProductDataClassDataContext();
            TestAPI.Models.product result = (from p in OdContext.products
                                             where p.productId == id
                                             select p).SingleOrDefault();
            result.productName = value.productName;
            result.price = value.price;
            OdContext.SubmitChanges();
        }

        public void Delete(int id)
        {
            ProductDataClassDataContext OdContext = new ProductDataClassDataContext();
            TestAPI.Models.product result = (from p in OdContext.products
                                             where p.productId == id
                                             select p).SingleOrDefault();
            OdContext.products.DeleteOnSubmit(result);
            OdContext.SubmitChanges();
        }
    }
}
