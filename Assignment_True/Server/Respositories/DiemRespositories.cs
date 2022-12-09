using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class DiemRespositories : IDiemRespositories

{
    private readonly Ass_C6Context _context;
    public DiemRespositories(Ass_C6Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Diem>> GetList()
    {
        return await _context.Diems.ToListAsync();
    }

    public async Task<Diem> Create(Diem diem)
    {
        diem.Status = true; 
        await _context.Diems.AddAsync(diem);
        await _context.SaveChangesAsync();
        return diem;
    }

    public async Task<Diem> Update(Diem diem)
    {
        _context.Entry(diem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return diem;
    }

    public async Task<Diem> Delete(Diem idem)
    {
        idem.Status = false;
        _context.Diems.Update(idem);
        await _context.SaveChangesAsync();
        return idem;
    }

    public async Task<Diem> GetById(string MaSV,string MaMonHoc)
    {
        return (await _context.Diems.FindAsync(MaSV,MaMonHoc))!;
    }
}