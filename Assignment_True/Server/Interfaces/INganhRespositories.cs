using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface INganhRespositories
{
    Task<IEnumerable<Nganh>> GetList();

    Task<Nganh> Create(Nganh nganh);
    Task<Nganh> Update(Nganh nganh);
    Task<Nganh> Delete(Nganh nganh);
    Task<Nganh> GetById(string id);
}