using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface IMonHocService
{
    Task<List<MonHoc>> GetList();

    Task<bool> Create(MonHoc monHoc);

    Task<bool> Update(string id, MonHoc monHoc);

    Task<bool> Delete(string id);

    Task<MonHoc> GetById(string id);
}