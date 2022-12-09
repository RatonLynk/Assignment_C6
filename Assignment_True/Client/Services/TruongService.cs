using Assignment_True.Client.Interfaces;
using Assignment_True.Shared.Models;
using System.Net.Http.Json;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Services;

public class TruongService : ITruongService
{
    public HttpClient _HttpClient;

    public TruongService(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<Truong>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Truong>>("api/Truongs/");
        return result!;
    }

    public async Task<bool> Create(Truong truong)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/Truongs/", truong);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(string id, Truong truong)
    {
        var result = await _HttpClient.PutAsJsonAsync($"api/Truongs/{id}", truong);
        return result.IsSuccessStatusCode;
    }

    public async Task<Truong> GetById(string id)
    {
        var result = await _HttpClient.GetFromJsonAsync<Truong>($"api/Truongs/{id}");
        return result!;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _HttpClient.DeleteAsync($"api/Truongs/{id}");
        return result.IsSuccessStatusCode;
    }
}