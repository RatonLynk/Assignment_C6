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
    public class LopsController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly ILopRespositories _respository;

        public LopsController(ILopRespositories respositories)
        {
            this._respository = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/Lops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lop>>> GetLops()
        {
            if (_context.Lops == null)
            {
                return NotFound();
            }
            try
            {
                return (await _respository.GetList()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ooga Booga Caveman Brane LOL!!!");

            }
        }

        // GET: api/Lops/5
        [HttpGet("{id}")]
        [ActionName("GetLop")]
        public async Task<ActionResult<Lop>> GetLop(string id)
        {
            if (_context.Lops == null)
            {
                return NotFound();
            }
            var Lop = await _respository.GetById(id);

            if (Lop == null)
            {
                return NotFound();
            }

            return Lop;
        }

        // PUT: api/Lops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLop(string id, Lop Lop)
        {
            if (id != Lop.MaLop)
            {
                return BadRequest();
            }

            try
            {
                await _respository.Update(Lop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_respository.GetById(id).IsFaulted)
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

        // POST: api/Lops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lop>> PostLop(Lop Lop)
        {
            if (_context.Lops == null)
            {
                return Problem("Entity set 'Ass_C6Context.Lops'  is null.");
            }
            try
            {
                if (Lop == null)
                {
                    return BadRequest();
                }
                await _respository.Create(Lop);
                return CreatedAtAction("GetLop", new { id = Lop.MaLop }, Lop);
            }
            catch (Exception)
            {

                throw;
            }
            //_context.Lops.Add(Lop);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (LopExists(Lop.MaLop))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        // DELETE: api/Lops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLop(string id)
        {
            if (_context.Lops == null)
            {
                return NotFound();
            }
            var Lop = await _respository.GetById(id);
            if (Lop == null)
            {
                return NotFound();
            }

            await _respository.Delete(Lop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LopExists(string id)
        {
            return (_context.Lops?.Any(e => e.MaLop == id)).GetValueOrDefault();
        }
    }
}
