using Assignment_True.Server.Interfaces;
using Assignment_True.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_True.Server.Respositories;

public class MonHocRespositories : IMonHocRespositories
{
    private readonly Ass_C6Context _context;
    public MonHocRespositories(Ass_C6Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MonHoc>> GetList()
    {
        return await _context.MonHocs.ToListAsync();
    }

    public async Task<MonHoc> Create(MonHoc monHoc)
    {
        monHoc.Status = true;
        await _context.MonHocs.AddAsync(monHoc);
        await _context.SaveChangesAsync();
        return monHoc;
    }

    public async Task<MonHoc> Update(MonHoc monHoc)
    {
        _context.Entry(monHoc).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return monHoc;
    }

    public async Task<MonHoc> Delete(MonHoc mon)
    {
        mon.Status = false;
        _context.MonHocs.Update(mon);
        await _context.SaveChangesAsync();
        return mon;
    }

    public async Task<MonHoc> GetById(string id)
    {
        return (await _context.MonHocs.FindAsync(id))!;
    }
}