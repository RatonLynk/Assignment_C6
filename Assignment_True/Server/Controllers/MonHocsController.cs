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
    public class MonHocsController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly IMonHocRespositories _respository;

        public MonHocsController(IMonHocRespositories respositories)
        {
            this._respository = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/MonHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocs()
        {
            if (_context.MonHocs == null)
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

        // GET: api/MonHocs/5
        [HttpGet("{id}")]
        [ActionName("GetMonHoc")]
        public async Task<ActionResult<MonHoc>> GetMonHoc(string id)
        {
            if (_context.MonHocs == null)
            {
                return NotFound();
            }
            var MonHoc = await _respository.GetById(id);

            if (MonHoc == null)
            {
                return NotFound();
            }

            return MonHoc;
        }

        // PUT: api/MonHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonHoc(string id, MonHoc MonHoc)
        {
            if (id != MonHoc.MaMonHoc)
            {
                return BadRequest();
            }

            try
            {
                await _respository.Update(MonHoc);
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> PostMonHoc(MonHoc MonHoc)
        {
            if (_context.MonHocs == null)
            {
                return Problem("Entity set 'Ass_C6Context.MonHocs'  is null.");
            }
            try
            {
                if (MonHoc == null)
                {
                    return BadRequest();
                }
                await _respository.Create(MonHoc);
                return CreatedAtAction("GetMonHoc", new { id = MonHoc.MaMonHoc }, MonHoc);
            }
            catch (Exception)
            {

                throw;
            }
            //_context.MonHocs.Add(MonHoc);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (MonHocExists(MonHoc.MaMonHoc))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(string id)
        {
            if (_context.MonHocs == null)
            {
                return NotFound();
            }
            var MonHoc = await _respository.GetById(id);
            if (MonHoc == null)
            {
                return NotFound();
            }

            await _respository.Delete(MonHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(string id)
        {
            return (_context.MonHocs?.Any(e => e.MaMonHoc == id)).GetValueOrDefault();
        }
    }
}
