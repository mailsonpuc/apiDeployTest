using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCursos.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //tem que a chave jwt para acessa
    public class CursoController : ControllerBase
    {
        private readonly CursoDbContext _context;

        public CursoController(CursoDbContext context)
        {
            _context = context;
        }

        // GET: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoItem>>> GetCursoItems()
        {
            return await _context.CursoItems.ToListAsync();
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoItem>> GetCursoItem(int id)
        {
            var cursoItem = await _context.CursoItems.FindAsync(id);

            if (cursoItem == null)
            {
                return NotFound();
            }

            return cursoItem;
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursoItem(int id, CursoItem cursoItem)
        {
            if (id != cursoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Curso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CursoItem>> PostCursoItem(CursoItem cursoItem)
        {
            _context.CursoItems.Add(cursoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCursoItem", new { id = cursoItem.Id }, cursoItem);
            return CreatedAtAction(nameof(GetCursoItem), new { id = cursoItem.Id }, cursoItem);

        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursoItem(int id)
        {
            var cursoItem = await _context.CursoItems.FindAsync(id);
            if (cursoItem == null)
            {
                return NotFound();
            }

            _context.CursoItems.Remove(cursoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursoItemExists(int id)
        {
            return _context.CursoItems.Any(e => e.Id == id);
        }
    }
}
