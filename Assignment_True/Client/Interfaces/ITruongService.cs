using Assignment_True.Shared.Models;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Interfaces;

public interface ITruongService
{
    Task<List<Truong>> GetList();

    Task<bool> Create(Truong truong);

    Task<bool> Update(string id, Truong truong);

    Task<bool> Delete(string id);

    Task<Truong> GetById(string id);
}