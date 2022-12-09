using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface ILopRespositories
{
    Task<IEnumerable<Lop>> GetList();

    Task<Lop> Create(Lop lop);
    Task<Lop> Update(Lop lop);
    Task<Lop> Delete(Lop lop);
    Task<Lop> GetById(string id);
}