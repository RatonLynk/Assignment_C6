using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface IDiemService
{
    Task<List<Diem>> GetList();

    Task<bool> Create(Diem diem);

    Task<bool> Update(string MaSv, string MaMonHoc, Diem diem);

    Task<bool> Delete(string MaSv, string MaMonHoc);

    Task<Diem> GetById(string MaSv, string MaMonHoc);
}