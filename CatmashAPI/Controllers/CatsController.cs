using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatmashAPI.Models;

namespace CatmashAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly CatmashContext _context;
        private Random rd = new Random();

        public CatsController(CatmashContext context)
        {
            _context = context;
        }

        // GET: api/Cats
        /// <summary>
        /// Get all Cat
        /// </summary>
        /// <returns>Array</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCats()
        {
            return await _context.Cat.ToListAsync();
        }

        // GET: api/Cats/Random
        /// <summary>
        /// Return list of two cat (randomly) for a duel 
        /// </summary>
        /// <returns>Array</returns>
        [HttpGet("random/")]
        public async Task<ActionResult<IEnumerable<Cat>>> GetTwoCatRandom()
        {
            return await _context.Cat.OrderBy(a => rd.Next()).Take(2).ToListAsync();
        }

        // GET: api/Cats/5
        /// <summary>
        /// Get Cat by Id
        /// </summary>
        /// <param name="id">Mandatory</param>
        /// <returns>Object Cat</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(string id)
        {
            var cat = await _context.Cat.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/Cats/5
        /// <summary>
        /// Upate  a Specific Cat
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Cats/5
        ///     {
        ///        "Id": "MTgwODA3MA",
        ///        "Url": "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg",
        ///        "Score": "0",
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="cat"></param>
        /// <returns>Object Cat</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Cat>> Update(string id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }
            if (cat.Score < 0)
                cat.Score = 0;
            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCat", new { id = cat.Id }, cat);
        }

        // POST: api/Cats
        /// <summary>
        /// Add a Cat
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Cats/
        ///     {
        ///        "Id": "MTgwODA3MA",
        ///        "Url": "http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg",
        ///        "Score": "0",
        ///     }
        /// </remarks>
        /// <param name="cat"></param>
        /// <returns>A newly created cat</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Cat>> Create(Cat cat)
        {
            if (!CatExists(cat.Id))
            {
                _context.Cat.Add(cat);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetCat", new { id = cat.Id }, cat);
        }

        // DELETE: api/Cats/5
        /// <summary>
        /// Delete a specific cat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cat>> DeleteCat(string id)
        {
            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cat.Remove(cat);
            await _context.SaveChangesAsync();

            return cat;
        }

        private bool CatExists(string id)
        {
            return _context.Cat.Any(e => e.Id == id);
        }
    }
}
