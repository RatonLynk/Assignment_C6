using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface INganhService
{
    Task<List<Nganh>> GetList();

    Task<bool> Create(Nganh nganh);

    Task<bool> Update(string id, Nganh nganh);

    Task<bool> Delete(string id);

    Task<Nganh> GetById(string id);
}