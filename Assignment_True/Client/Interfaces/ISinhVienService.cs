using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface ISinhVienService
{
    Task<List<SinhVien>> GetList();

    Task<bool> Create(SinhVien sinhVien);

    Task<bool> Update(string id, SinhVien sinhVien);

    Task<bool> Delete(string id);

    Task<SinhVien> GetById(string id);
}