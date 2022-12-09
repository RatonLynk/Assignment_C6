using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface ILopService
{
    Task<List<Lop>> GetList();

    Task<bool> Create(Lop lop);

    Task<bool> Update(string id, Lop lop);

    Task<bool> Delete(string id);

    Task<Lop> GetById(string id);
}