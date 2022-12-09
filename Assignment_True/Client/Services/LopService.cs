using Assignment_True.Client.Interfaces;
using Assignment_True.Shared.Models;
using System.Net.Http.Json;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Services;


    public class LopService : ILopService
    {
        public HttpClient _HttpClient;

        public LopService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<bool> Create(Lop lop)
        {
            var result = await _HttpClient.PostAsJsonAsync("api/Lops/", lop);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _HttpClient.DeleteAsync($"api/Lops/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<Lop> GetById(string id)
        {
            var result = await _HttpClient.GetFromJsonAsync<Lop>($"api/Lops/{id}");
            return result!;
        }

        public async Task<List<Lop>> GetList()
        {
            var result = await _HttpClient.GetFromJsonAsync<List<Lop>>("api/Lops/");
            return result!;
        }

        public async Task<bool> Update(string id, Lop lop)
        {
            var result = await _HttpClient.PutAsJsonAsync($"api/Lops/{id}", lop);
            return result.IsSuccessStatusCode;
        }
    }
