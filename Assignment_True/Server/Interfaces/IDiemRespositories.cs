using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface IDiemRespositories
{
    Task<IEnumerable<Diem>> GetList();

    Task<Diem> Create(Diem diem);
    Task<Diem> Update(Diem diem);
    Task<Diem> Delete(Diem idem);
    Task<Diem> GetById(string MaSV, string MaMonHoc);
}