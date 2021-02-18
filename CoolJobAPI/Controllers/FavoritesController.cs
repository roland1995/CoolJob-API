using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoolJobAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace CoolJobAPI.Controllers
{
    [EnableCors("Access-Control-Allow-Origin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteContext _context;

        public FavoritesController (FavoriteContext context)
            {
            _context = context;
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetFavoriteJobs()
        {
            return await _context.Favorites.ToListAsync();
        }

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
