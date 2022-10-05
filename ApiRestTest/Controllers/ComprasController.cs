using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestTest.Contexts;
using ApiRestTest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    public class ComprasController : Controller
    {
        private readonly ConexionSQLServer context;

        public ComprasController(ConexionSQLServer context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ComprasDO comprasDO = new ComprasDO();
                List<Compra> compras = comprasDO.getCompras(context);
                return Ok(compras);
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
                ComprasDO comprasDO = new ComprasDO();
                List<Compra> compras = comprasDO.getCompras(context);
                compras = compras.Where(x => x.id == id).ToList();
                return Ok(compras);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] List<Compra> compras)
        {
            try
            {
                ComprasDO comprasDO = new ComprasDO();
                string respuesta = comprasDO.insertarCompra(context, compras, DateTime.Now);
                return Ok(respuesta);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

