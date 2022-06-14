using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Dominio.EntidadesNegocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        // GET: api/<AutoresController>
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return new List<Autor>() { new Autor() { Id=1, Nombre="Juan Perez", Nacionalidad="Uruguay"} };
        }

        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        public Autor Get(int id)
        {
            return new Autor() { Id = id, Nombre = "Juan Perez", Nacionalidad = "Uruguay" };
        }

        // POST api/<AutoresController>
        [HttpPost]
        public void Post([FromBody] Autor autor)
        {
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Autor autor)
        {
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
