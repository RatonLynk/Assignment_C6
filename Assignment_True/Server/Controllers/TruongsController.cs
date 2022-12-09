using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_True.Shared.Models;
using Assignment_True.Server.Interfaces;
using Assignment_True.Server.Respositories;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_True.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TruongsController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly ITruongRespositories _truongRespositories;

        public TruongsController(ITruongRespositories respositories)
        {
            this._truongRespositories = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/Truongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truong>>> GetTruongs()
        {
          if (_context.Truongs == null)
          {
              return NotFound();
          }
            try
            {
                return (await _truongRespositories.GetList()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ooga Booga Caveman Brane LOL!!!");
                
            }
        }

        // GET: api/Truongs/5
        [HttpGet("{id}")]
        [ActionName("GetTruong")]
        public async Task<ActionResult<Truong>> GetTruong(string id)
        {
          if (_context.Truongs == null)
          {
              return NotFound();
          }
            var truong = await _truongRespositories.GetById(id);

            if (truong == null)
            {
                return NotFound();
            }

            return truong;
        }

        // PUT: api/Truongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruong(string id, Truong truong)
        {
            if (id != truong.MaTruong)
            {
                return BadRequest();
            }

            try
            {
                await _truongRespositories.Update(truong);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_truongRespositories.GetById(id).IsFaulted)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ooga Booga Caveman Brane LOL!!!");
                }
            }

            return NoContent();
        }

        // POST: api/Truongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Truong>> PostTruong(Truong truong)
        {
          if (_context.Truongs == null)
          {
              return Problem("Entity set 'Ass_C6Context.Truongs'  is null.");
          }
            try
            {
                if (truong == null)
                {
                    return BadRequest();
                }
                await _truongRespositories.Create(truong);
                return CreatedAtAction("GetTruong", new { id = truong.MaTruong }, truong);
            }
            catch (Exception)
            {

                throw;
            }
            //_context.Truongs.Add(truong);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (TruongExists(truong.MaTruong))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        // DELETE: api/Truongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruong(string id)
        {
            if (_context.Truongs == null)
            {
                return NotFound();
            }
            var truong = await _truongRespositories.GetById(id);
            if (truong == null)
            {
                return NotFound();
            }

            await _truongRespositories.Delete(truong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruongExists(string id)
        {
            return (_context.Truongs?.Any(e => e.MaTruong == id)).GetValueOrDefault();
        }
    }
}
