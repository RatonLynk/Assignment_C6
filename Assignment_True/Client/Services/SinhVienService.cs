using Assignment_True.Client.Interfaces;
using Assignment_True.Shared.Models;
using System.Net.Http.Json;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Services;

public class SinhVienService : ISinhVienService
{
    public HttpClient _HttpClient;

    public SinhVienService(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<SinhVien>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<SinhVien>>("api/SinhViens/");
        return result!;
    }

    public async Task<bool> Create(SinhVien sinhVien)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/SinhViens/", sinhVien);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(string id, SinhVien sinhVien)
    {
        var result = await _HttpClient.PutAsJsonAsync($"api/SinhViens/{id}", sinhVien);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _HttpClient.DeleteAsync($"api/SinhViens/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<SinhVien> GetById(string id)
    {
        var result = await _HttpClient.GetFromJsonAsync<SinhVien>($"api/SinhViens/{id}");
        return result!;
    }
}