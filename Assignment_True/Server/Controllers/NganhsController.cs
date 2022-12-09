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
    public class NganhsController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly INganhRespositories _respository;

        public NganhsController(INganhRespositories respositories)
        {
            this._respository = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/Truongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nganh>>> GetNganhs()
        {
            if (_context.Nganhs == null)
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

        // GET: api/Truongs/5
        [HttpGet("{id}")]
        [ActionName("GetTruong")]
        public async Task<ActionResult<Nganh>> GetTruong(string id)
        {
            if (_context.Nganhs == null)
            {
                return NotFound();
            }
            var nganh = await _respository.GetById(id);

            if (nganh == null)
            {
                return NotFound();
            }

            return nganh;
        }

        // PUT: api/Truongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNganh(string id, Nganh sinhVien)
        {
            if (id != sinhVien.MaNganh)
            {
                return BadRequest();
            }

            try
            {
                await _respository.Update(sinhVien);
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

        // POST: api/Truongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Truong>> PostTruong(Nganh sinhVien)
        {
            if (_context.Truongs == null)
            {
                return Problem("Entity set 'Ass_C6Context.Truongs'  is null.");
            }
            try
            {
                if (sinhVien == null)
                {
                    return BadRequest();
                }
                await _respository.Create(sinhVien);
                return CreatedAtAction("GetTruong", new { id = sinhVien.MaNganh }, sinhVien);
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
        public async Task<IActionResult> DeleteNganh(string id)
        {
            if (_context.SinhViens == null)
            {
                return NotFound();
            }
            var sinhVien = await _respository.GetById(id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            await _respository.Delete(sinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruongExists(string id)
        {
            return (_context.Truongs?.Any(e => e.MaTruong == id)).GetValueOrDefault();
        }
    }
}
