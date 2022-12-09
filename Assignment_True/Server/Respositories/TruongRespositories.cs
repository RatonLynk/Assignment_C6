using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class TruongRespositories : ITruongRespositories
{
    private readonly Ass_C6Context _context;
    public TruongRespositories(Ass_C6Context context)
    {
        this._context = context;
    }
    public async Task<IEnumerable<Truong>> GetList()
    {
        return await _context.Truongs.ToListAsync();
    }

    public async Task<Truong> Create(Truong truong)
    {
        truong.Status = true;
        await _context.Truongs.AddAsync(truong);
        await _context.SaveChangesAsync();
        return truong;
    }

    public async Task<Truong> Update(Truong truong)
    {
        _context.Entry(truong).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return truong;
    }

    public async Task<Truong> Delete(Truong truong)
    {
        truong.Status = false;
        return await Update(truong);
    }

    public async Task<Truong> GetById(string id)
    {
        return (await _context.Truongs.FirstOrDefaultAsync(c=>c.MaTruong == id))!;
    }
}