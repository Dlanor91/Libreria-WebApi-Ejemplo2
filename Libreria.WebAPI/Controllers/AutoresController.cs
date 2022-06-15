using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Libreria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public IRepositorioAutor RepoAutores { get; set; }

        public AutoresController(IRepositorioAutor repo)
        {
            RepoAutores=repo;
        }

        // GET: api/<AutoresController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RepoAutores.FindAll());
            //El OK es el 200 del body o respuesta
        }

        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        //para via 2 de post [Route("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id ==0) return BadRequest();
                Autor buscado = RepoAutores.FindById(id);
                if (buscado == null) return NotFound();

                return Ok(buscado);

            }
            catch (Exception )
            {

                return StatusCode(500);
            }
        }

        // POST api/<AutoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Autor autor)
        {
            try
            {
                //la ruta y el recurso creado debo tener ambas
                //Ese get es de la id de find by id 
                if (!autor.Validar()) return BadRequest();
                bool ok = RepoAutores.Add(autor);
                if (!ok) return Conflict();

                return Created("api/autores"+autor.Id, autor);
                //si viene un dato mal debe retornar un badrequest q es un 400

                //otra via return CreatedAtRoute("Get", new {id = autor.Id}, autor);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autor autor)
        {
            try
            {
                if (autor.Id != 0 && id == autor.Id)
                {
                    bool ok = RepoAutores.Update(autor);
                    if (!ok) return Conflict();
                }
                else
                {
                    return BadRequest();
                }

                return Ok(autor);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)//retorna un 204 como status code
        {
            try
            {
                if (id ==0) return BadRequest();
                Autor buscado = RepoAutores.FindById(id);
                if (buscado == null) return NotFound();

                bool ok = RepoAutores.Remove(id);
                if (!ok) return Conflict();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
