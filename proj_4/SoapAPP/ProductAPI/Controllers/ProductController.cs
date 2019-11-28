using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>{
                new Product{
                    ProductId=1,
                    Name = "Toyota",
                    Description ="Corolla"
                },
                new Product{
                    ProductId=2,
                    Name = "Porsche",
                    Description ="Cayen"
                },
            };
        }

        [Route("api/[controller]/{ProductId}")]
        public IEnumerable<Product> Get(int id)
        {
            return new List<Product>{
                new Product{
                    ProductId=1,
                    Name = "Toyota",
                    Description ="Corolla"
                }
            };
        }
    }




}