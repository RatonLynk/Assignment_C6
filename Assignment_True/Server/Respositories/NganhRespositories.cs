using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class NganhRespositories : INganhRespositories
{
    private readonly Ass_C6Context _context;
    public NganhRespositories(Ass_C6Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Nganh>> GetList()
    {
        return await _context.Nganhs.ToListAsync();
    }

    public async Task<Nganh> Create(Nganh nganh)
    {
        nganh.Status = true;
        await _context.Nganhs.AddAsync(nganh);
        await _context.SaveChangesAsync();
        return nganh;
    }

    public async Task<Nganh> Update(Nganh nganh)
    {
        _context.Entry(nganh).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return nganh;
    }

    public async Task<Nganh> Delete(Nganh nganh)
    {
        nganh.Status = false;
        _context.Nganhs.Update(nganh);
        await _context.SaveChangesAsync();
        return nganh;
    }

    public async Task<Nganh> GetById(string id)
    {
        return (await _context.Nganhs.FindAsync(id))!;
    }
}