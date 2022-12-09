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
    public class DiemsController : ControllerBase
    {
        private readonly Ass_C6Context _context;
        private readonly IDiemRespositories _respository;

        public DiemsController(IDiemRespositories respositories)
        {
            this._respository = respositories;
            _context = new Ass_C6Context();
        }

        // GET: api/Diems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiems()
        {
            if (_context.Diems == null)
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

        // GET: api/Diems/5
        [HttpGet("{MaSV}/{MaMonHoc}")]
        [ActionName("GetDiem")]
        public async Task<ActionResult<Diem>> GetDiem(string MaSV, string MaMonHoc)
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            var Diem = await _respository.GetById(MaSV, MaMonHoc);

            if (Diem == null)
            {
                return NotFound();
            }

            return Diem;
        }

        // PUT: api/Diems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(string MaSV, string MaMonHoc, Diem Diem)
        {
            if (MaSV != Diem.MaSv || MaMonHoc != Diem.MaMonHoc)
            {
                return BadRequest();
            }

            try
            {
                await _respository.Update(Diem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_respository.GetById(MaSV,MaMonHoc).IsFaulted)
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

        // POST: api/Diems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem Diem)
        {
            if (_context.Diems == null)
            {
                return Problem("Entity set 'Ass_C6Context.Diems'  is null.");
            }
            try
            {
                if (Diem == null)
                {
                    return BadRequest();
                }
                await _respository.Create(Diem);
                return CreatedAtAction("GetDiem", new { msv = Diem.MaSv, mmh = Diem.MaMonHoc }, Diem);
            }
            catch (Exception)
            {

                throw;
            }
            //_context.Diems.Add(Diem);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (DiemExists(Diem.MaDiem))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        // DELETE: api/Diems/5
        [HttpDelete("{MaSV}/{MaMonHoc}")]
        public async Task<IActionResult> DeleteDiem(string MaSV, string MaMonHoc)
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            var Diem = await _respository.GetById(MaSV, MaMonHoc);
            if (Diem == null)
            {
                return NotFound();
            }

            await _respository.Delete(Diem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiemExists(string MaSV, string MaMonHoc)
        {
            return (_context.Diems?.Any(e => e.MaSv == MaSV && e.MaMonHoc == MaMonHoc)).GetValueOrDefault();
        }
    }
}
