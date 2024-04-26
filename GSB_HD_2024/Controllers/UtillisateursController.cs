using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSB_HD_2024.Models;

namespace GSB_HD_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtillisateursController : ControllerBase
    {
        private readonly BtsBddContext _context;

        public UtillisateursController(BtsBddContext context)
        {
            _context = context;
        }

        // GET: api/Utillisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utillisateur>>> GetUtillisateurs()
        {
          if (_context.Utillisateurs == null)
          {
              return NotFound();
          }
            return await _context.Utillisateurs.ToListAsync();
        }

        // GET: api/Utillisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utillisateur>> GetUtillisateur(int id)
        {
          if (_context.Utillisateurs == null)
          {
              return NotFound();
          }
            var utillisateur = await _context.Utillisateurs.FindAsync(id);

            if (utillisateur == null)
            {
                return NotFound();
            }

            return utillisateur;
        }

        // PUT: api/Utillisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtillisateur(int id, Utillisateur utillisateur)
        {
            if (id != utillisateur.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(utillisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtillisateurExists(id))
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

        // POST: api/Utillisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utillisateur>> PostUtillisateur(Utillisateur utillisateur)
        {
          if (_context.Utillisateurs == null)
          {
              return Problem("Entity set 'BtsBddContext.Utillisateurs'  is null.");
          }
            _context.Utillisateurs.Add(utillisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtillisateur", new { id = utillisateur.IdUser }, utillisateur);
        }

        // DELETE: api/Utillisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtillisateur(int id)
        {
            if (_context.Utillisateurs == null)
            {
                return NotFound();
            }
            var utillisateur = await _context.Utillisateurs.FindAsync(id);
            if (utillisateur == null)
            {
                return NotFound();
            }

            _context.Utillisateurs.Remove(utillisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtillisateurExists(int id)
        {
            return (_context.Utillisateurs?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }
    }
}
