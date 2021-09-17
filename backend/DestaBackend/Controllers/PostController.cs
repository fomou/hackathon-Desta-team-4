using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DestaNationConnect.DataAccessLayer;
using DestaNationConnect.DataAccessLayer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DestaNationConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DestaNationConnectContext _context;

        public PostController(DestaNationConnectContext context)
        {
            _context = context;
        }
        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }


       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(long id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> Postpost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }



       


        // DELETE: api/post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool PostExists(long id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
