using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface IMonHocRespositories
{
    Task<IEnumerable<MonHoc>> GetList();

    Task<MonHoc> Create(MonHoc monHoc);
    Task<MonHoc> Update(MonHoc monHoc);
    Task<MonHoc> Delete(MonHoc mon);
    Task<MonHoc> GetById(string id);
}