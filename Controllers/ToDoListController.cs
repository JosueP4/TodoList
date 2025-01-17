using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TO_DO_LIST.Context;
using TO_DO_LIST.Model;

namespace TO_DO_LIST.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ToDoListController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        [Route("Lista")]


        public async Task<ActionResult<List<Lista>>> ListaT()
        {
            var listas = await _context.Listas.ToListAsync();
            return Ok(listas);
        }

        [Authorize]
        [HttpGet]
        [Route("Buscar/{id}")]
        
        public async Task<ActionResult<List<Lista>>> Buscar(int id)
        {
            var lista = await _context.Listas.FindAsync(id);

            if (lista == null)
            {
                return BadRequest("no se encontro el ID");
            }

            return Ok(lista);
        }
        [Authorize]
        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<List<Lista>>> Crear(Lista lista)
        {
            lista.tareaC = false;
            await _context.Listas.AddAsync(lista);
            await _context.SaveChangesAsync();
            return Ok(lista);
        }
        [Authorize]
        [HttpPut]
        [Route("Editar/{id}")]

        public async Task<ActionResult<List<Lista>>> Editar(int id, Lista lista)
        {
            if (id != lista.id)
            {
                return BadRequest("No se encontro el id");
            }

            _context.Listas.Update(lista);
            await _context.SaveChangesAsync();  
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        [Route("Elimnar/{id}")]

        public async Task<ActionResult<List<Lista>>> Elimnar(int id)
        {
            var lista = await _context.Listas.FindAsync(id);
            if ( lista == null)
            {
                return BadRequest("NO SE ENCONTRO");
            }
            _context.Listas.Remove(lista);
            await _context.SaveChangesAsync();
            return Ok(lista);
        }
        [Authorize]
        [HttpGet]
        [Route("Pendientes")]

        public async Task<ActionResult<List<Lista>>> Pendientes()
        {
            var lista = await _context.Listas.Where(w => w.tareaC == false).ToListAsync();
            if (lista == null)
            {
                return BadRequest();
            }
            return Ok(lista);
        }
        [Authorize]
        [HttpGet]
        [Route("Completado")]

        public async Task<ActionResult<List<Lista>>> Completado()
        {
            var lista = await _context.Listas.Where(w => w.tareaC == true).ToListAsync();


            if (lista == null)
            {
                return BadRequest();
            }
            /*
            lista.tareaC = true;
            await _context.SaveChangesAsync();
            */
            return Ok(lista);
        }
    }
}
