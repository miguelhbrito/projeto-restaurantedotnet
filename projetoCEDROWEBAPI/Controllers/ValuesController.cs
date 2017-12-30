using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoCEDROWEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace projetoCEDROWEBAPI.Controllers
{
    [Route("api/")]
    public class ValuesController : Controller
    {
        private readonly RestauranteContext _context;

        public ValuesController(RestauranteContext context)
        {
            _context = context;

        }

        //GET api/pratosrestaurantes
        //Retorna todos os pratos de todos os restaurantes
        [HttpGet("pratosrestaurantes")]
        public List<string> GetPratosRestaurantes()
        {
            List<string> lista = new List<string> ();
            
            foreach ( Prato prato in _context.Pratos.ToList())
            {
                var auxNome = _context.Restaurantes.Where(p => p.Id == prato.RestauranteIdRef).FirstOrDefault();
                lista.Add(auxNome.Nome+" "+prato.IdPrato+" "+prato.Nome+" "+prato.Preco);
            }
            return lista.ToList();
        }

        // GET api/restaurantes 
        //TODOS RESTAURANTES
        [HttpGet("restaurantes")]
        public IEnumerable<Restaurante> GetAllRestaurantes()
        {
            return _context.Restaurantes.ToList();
        }

        //GET api/pratos
        //GET PRATOS
        [HttpGet("pratos")]
        public IEnumerable<Prato> GetAllPratos()
        {
            return _context.Pratos.ToList();
        }

        //GET api/restaurantesnome
        //GET Restaurante por nome -- nome por argumento na URL
        [HttpGet("restaurantesnome/{nome}", Name = "GetRestaurante")]
        public IActionResult GetByName(string nome)
        {
            var item = _context.Restaurantes.Where(r => r.Nome.Equals(nome));
            if (item.FirstOrDefault() == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //GET api/pratosnome
        //GET Pratos por nome -- nome por argumento na URL
        [HttpGet("pratosnome/{nome}", Name = "GetPrato")]
        public IActionResult GetByNamePrato(string nome)
        {
            var item = _context.Pratos.Where(r => r.Nome.Equals(nome));
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/postrestaurantes
        // POST Adicionar restaurantes 
        [HttpPost("postrestaurantes")]
        public IActionResult CreateRestaurante([FromBody]Restaurante unid)
        {
            if (unid == null)
            {
                return BadRequest();
            }

            _context.Restaurantes.Add(unid);
            _context.SaveChanges();

            return CreatedAtRoute("GetRestaurante", new { id = unid.Id }, unid);
        }

        //Retornar o nome do restaurante de um determinado prato 
        [HttpGet("nome/{id}", Name ="ReturnNameRest")]
        public string teste(long id)
        {
            var pratoAux = _context.Pratos.Where(p => p.IdPrato == id).FirstOrDefault();
            var restauranteAux = _context.Restaurantes.Where(t => t.Id == pratoAux.RestauranteIdRef).FirstOrDefault();
            return  (restauranteAux.Nome);
        }

        //POST api/postpratos
        //POST Adicionar pratos 
        [HttpPost("postpratos")]
        public IActionResult CreatePrato([FromBody]Prato unid)
        {
            if (unid == null)
            {
                return BadRequest();
            }

            var aux = _context.Restaurantes.Where(t => t.Id == unid.RestauranteIdRef).FirstOrDefault();

            unid.Restaurante = aux;

            _context.Pratos.Add(unid);

            _context.SaveChanges();

            return CreatedAtRoute("GetPrato", new { id = unid.IdPrato }, unid);
        }

        //PUT api/putrestaurantes/id
        //PUT Update Restaurantes -- id por argumento na URL
        [HttpPut("putrestaurantes/{id}")]
        public IActionResult Update(long id, [FromBody]Restaurante item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var aux = _context.Restaurantes.FirstOrDefault(t => t.Id == id);
            if (aux == null)
            {
                return NotFound();
            }

            aux.Nome = item.Nome;

            _context.Restaurantes.Update(aux);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //PUT api/putpratos/id
        //PUT Update Pratos -- id por argumento na URL
        [HttpPut("putpratos/{id}")]
        public IActionResult UpdatePrato(long id, [FromBody]Prato item)
        {
            if (item == null || item.IdPrato != id)
            {
                return BadRequest();
            }

            var aux = _context.Pratos.FirstOrDefault(t => t.IdPrato == id);
            if (aux == null)
            {
                return NotFound();
            }

            aux.RestauranteIdRef = item.RestauranteIdRef;
            aux.Restaurante = item.Restaurante;
            aux.Preco = item.Preco;
            aux.Nome = item.Nome;

            _context.Pratos.Update(aux);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //DELETE api/deleterestaurantes/id 
        //DELETE Restaurantes -- id por argumento na URL
        [HttpDelete("deleterestaurantes/{id}", Name = "DeleteRestaurantes")]
        public IActionResult Delete(long id)
        {
            var aux = _context.Restaurantes.FirstOrDefault(t => t.Id == id);
            if (aux == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(aux);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //DELETE api/deletepratos/id 
        //DELETE Pratos -- id por argumento na URL
        [HttpDelete("deletepratos/{id}", Name = "DeletePratos")]
        public IActionResult DeletePrato(long id)
        {
            var aux = _context.Pratos.FirstOrDefault(t => t.IdPrato == id);
            if (aux == null)
            {
                return NotFound();
            }

            _context.Pratos.Remove(aux);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
