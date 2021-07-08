using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;

namespace ProductCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        [Produces("application/json")]
        [HttpGet("findall")]

        public async Task<IActionResult> findAll()
        {
            try
            {
                var products = db.Product.ToList();
                return Ok(products);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                db.Product.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpGet("find/{id}")]
        public async Task<IActionResult> find(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                return Ok(product);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(product);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Product.Remove(db.Product.Find(id));
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}