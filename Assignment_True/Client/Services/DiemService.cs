using Assignment_True.Client.Interfaces;
using Assignment_True.Shared.Models;
using System.Net.Http.Json;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Services;

public class DiemService : IDiemService
{
    public HttpClient _HttpClient;

    public DiemService(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<bool> Create(Diem diem)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/Diems/", diem);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(string MaSv, string MaMonHoc)
    {
        var result = await _HttpClient.DeleteAsync($"api/Diems/{MaSv}/{MaMonHoc}");
        return result.IsSuccessStatusCode;
    }

    public async Task<Diem> GetById(string MaSv, string MaMonHoc)
    {
        var result = await _HttpClient.GetFromJsonAsync<Diem>($"api/Diems/{MaSv}/{MaMonHoc}");
        return result!;
    }

    public async Task<List<Diem>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Diem>>("api/Diems/");
        return result!;
    }

    public async Task<bool> Update(string MaSv, string MaMonHoc, Diem diem)
    {
        var result = await _HttpClient.PostAsJsonAsync($"api/Diems/{MaSv}/{MaMonHoc}", diem);
        return result.IsSuccessStatusCode;
    }
}