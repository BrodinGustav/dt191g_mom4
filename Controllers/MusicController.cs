using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dt191g_mom4.Data;
using dt191g_mom4.Models;

namespace dt191g_mom4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly MusicDbContext _context;

        public MusicController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: api/Music
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusic()
        {
            return await _context.Music.ToListAsync();
        }

        // GET: api/Music/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }

            return music;
        }

        // PUT: api/Music/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, Music music)
        {
            if (id != music.Id)
            {
                return BadRequest();
            }

            _context.Entry(music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
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

        // POST: api/Music
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusic", new { id = music.Id }, music);
        }

        // DELETE: api/Music/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Music.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.Id == id);
        }
    }
}
