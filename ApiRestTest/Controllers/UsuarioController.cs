using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiRestTest.Contexts;
using ApiRestTest.Models;
using ApiRestTest.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public UsuarioController(ConexionSQLServer context)
        {
            this.context = context;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                UsuarioDO usuarioDO = new UsuarioDO();
                List<Usuario> usuarios = usuarioDO.getUsuarios(context);
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // GET: api/values
        [HttpGet]
        [Route("getBuyByUser")]
        public IActionResult GetCompras(int id)
        {
            try
            {
                List<ComprasPorUsuario> compras = new List<ComprasPorUsuario>();
                if(id == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    ComprasDO comprasDO = new ComprasDO();
                    compras = comprasDO.getComprasPorUsuario(context, id);
                }
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
                UsuarioDO usuarioDO = new UsuarioDO();
                List<Usuario> usuarios = usuarioDO.getUsuarios(context);
                usuarios = usuarios.Where(x => x.id == id).ToList();
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Usuario user)
        {
            try
            {
                Usuario usuario = new Usuario();
                if(user.UserEmail == null && user.UserPassword == null && user.UserName == null && user.UserDNI == null && user.UserAge == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    UsuarioDO usuarioDO = new UsuarioDO();
                    usuario = usuarioDO.insertUsuario(context, user);
                }
                return Ok(usuario);
            }
            catch
            {
                return BadRequest("Error.");
            }
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Usuario user)
        {
            try
            {
                Usuario usuario = new Usuario();
                if (user.id == 0 && user.UserEmail == null && user.UserPassword == null && user.UserName == null && user.UserLastName == null && user.UserDNI == null && user.UserAge == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    UsuarioDO usuarioDO = new UsuarioDO();
                    usuario = usuarioDO.modificarUsuario(context, user);
                }
                return Ok(usuario);
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
                if(id == 0)
                {
                    return BadRequest("Error.");
                }
                else
                {
                    UsuarioDO usuarioDO = new UsuarioDO();
                    respuesta = usuarioDO.eliminarUsuario(context,id);
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

