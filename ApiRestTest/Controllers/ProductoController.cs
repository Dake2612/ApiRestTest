using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiRestTest.Contexts;
using ApiRestTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly ConexionSQLServer context;

        public ProductoController(ConexionSQLServer context)
        {
            this.context = context;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ProductosDO productosDO = new ProductosDO();
                List<Producto> productos = productosDO.getProductos(context);
                return Ok(productos);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProductosDO productosDO = new ProductosDO();
                List<Producto> productos = productosDO.getProductos(context);
                productos = productos.Where(x => x.id == id).ToList();
                return Ok(productos);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Producto product)
        {
            try
            {
                Producto producto = new Producto();
                if(product.ProductName == null && product.ProductWeigth == 0.0 && product.ProductHeight == 0.0 && product.ProductWidth == 0.0 && product.ProductCount == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    ProductosDO productosDO = new ProductosDO();
                    producto = productosDO.insertProducto(context, product);
                }
                return Ok(producto);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Producto product)
        {
            try
            {
                Producto producto = new Producto();
                if (product.id == 0 && product.ProductName == null && product.ProductWeigth == 0.0 && product.ProductHeight == 0.0 && product.ProductWidth == 0.0 && product.ProductCount == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    ProductosDO productosDO = new ProductosDO();
                    producto = productosDO.modificarProducto(context, product);
                }
                return Ok(producto);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                string respuesta = "";
                if (id == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    ProductosDO productosDO = new ProductosDO();
                    respuesta = productosDO.eliminarProducto(context, id);
                }
                return Ok(respuesta);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }
    }
}

