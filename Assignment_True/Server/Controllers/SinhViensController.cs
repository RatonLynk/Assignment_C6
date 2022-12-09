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
    public class SinhViensController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly ISinhVienRespositories _respository;

        public SinhViensController(ISinhVienRespositories respositories)
        {
            this._respository = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/SinhViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
        {
          if (_context.SinhViens == null)
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

        // GET: api/SinhViens/5
        [HttpGet("{id}")]
        [ActionName("GetSinhVien")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(string id)
        {
          if (_context.SinhViens == null)
          {
              return NotFound();
          }
            var SinhVien = await _respository.GetById(id);

            if (SinhVien == null)
            {
                return NotFound();
            }

            return SinhVien;
        }

        // PUT: api/SinhViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien(string id, SinhVien sinhVien)
        {
            if (id != sinhVien.MaSv)
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

        // POST: api/SinhViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhVien)
        {
          if (_context.SinhViens == null)
          {
              return Problem("Entity set 'Ass_C6Context.SinhViens'  is null.");
          }
            try
            {
                if (sinhVien == null)
                {
                    return BadRequest();
                }
                await _respository.Create(sinhVien);
                return CreatedAtAction("GetSinhVien", new { id = sinhVien.MaSv }, sinhVien);
            }
            catch (Exception)
            {

                throw;
            }
            //_context.SinhViens.Add(SinhVien);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (SinhVienExists(SinhVien.MaSinhVien))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        // DELETE: api/SinhViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(string id)
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

        private bool SinhVienExists(string id)
        {
            return (_context.SinhViens?.Any(e => e.MaSv == id)).GetValueOrDefault();
        }
    }
}
