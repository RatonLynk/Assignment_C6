using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class SinhVienRespositories : ISinhVienRespositories
{
    private readonly Ass_C6Context _context;
    public SinhVienRespositories(Ass_C6Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<SinhVien>> GetList()
    {
        return await _context.SinhViens.ToListAsync();
    }

    public async Task<SinhVien> Create(SinhVien sinhVien)
    {
        sinhVien.Status = true;
        await _context.SinhViens.AddAsync(sinhVien);
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> Update(SinhVien sinhVien)
    {
        _context.Entry(sinhVien).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> Delete(SinhVien sinhVien)
    {
        sinhVien.Status = false;
        _context.SinhViens.Update(sinhVien);
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> GetById(string id)
    {
        return (await _context.SinhViens.FindAsync(id))!;
    }
}