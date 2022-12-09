using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class LopRespositories : ILopRespositories
{
    private readonly Ass_C6Context _context;
    public LopRespositories(Ass_C6Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Lop>> GetList()
    {
        return await _context.Lops.ToListAsync();
    }

    public async Task<Lop> Create(Lop lop)
    {
        lop.Status = true;
        await _context.Lops.AddAsync(lop);
        await _context.SaveChangesAsync();
        return lop;
    }

    public async Task<Lop> Update(Lop lop)
    {
        _context.Entry(lop).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return lop;
    }

    public async Task<Lop> Delete(Lop lov)
    {
        lov.Status = false;
        _context.Lops.Update(lov);
        await _context.SaveChangesAsync();
        return lov;
    }

    public async Task<Lop> GetById(string id)
    {
        return (await _context.Lops.FindAsync(id))!;
    }
}