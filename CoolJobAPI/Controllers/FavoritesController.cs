using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoolJobAPI.Models;


namespace CoolJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteContext _context;

        public FavoritesController (FavoriteContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetFavoriteJobs()
        {
            return await _context.Favorites.ToListAsync();
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetFavoriteJob(string id)
        {
            var job = await _context.Favorites.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        //POST: api/Jobs
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Job>> PostFavoriteJob(Job job)
        {
            _context.Favorites.Add(job);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobExists(job.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetFavoriteJob), new { id = job.Id }, job);
        }


        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteJob(string id)
        {
            var job = await _context.Favorites.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(string id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
 
}
