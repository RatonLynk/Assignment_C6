using Assignment_True.Shared.Models;

namespace Assignment_True.Server.Interfaces;

public interface ITruongRespositories
{
    Task<IEnumerable<Truong>> GetList();

    Task<Truong> Create(Truong truong);
    Task<Truong> Update(Truong truong);
    Task<Truong> Delete(Truong truong);
    Task<Truong> GetById(string id);
}