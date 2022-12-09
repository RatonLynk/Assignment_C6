using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface ISinhVienRespositories
{
    Task<IEnumerable<SinhVien>> GetList();

    Task<SinhVien> Create(SinhVien sinhVien);
    Task<SinhVien> Update(SinhVien sinhVien);
    Task<SinhVien> Delete(SinhVien sinhVien);
    Task<SinhVien> GetById(string id);
}