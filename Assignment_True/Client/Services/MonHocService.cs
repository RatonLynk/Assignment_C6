using Assignment_True.Client.Interfaces;
using Assignment_True.Shared.Models;
using System.Net.Http.Json;
using Diem = Assignment_True.Shared.Models.Diem;

namespace Assignment_True.Client.Services;


public class MonHocService : IMonHocService
    {
        public HttpClient _HttpClient;

        public MonHocService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<bool> Create(MonHoc monHoc)
        {
            var result = await _HttpClient.PostAsJsonAsync("api/MonHocs/", monHoc);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _HttpClient.DeleteAsync($"api/MonHocs/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<MonHoc> GetById(string id)
        {
            var result = await _HttpClient.GetFromJsonAsync<MonHoc>($"api/MonHocs/{id}");
            return result!;
        }

        public async Task<List<MonHoc>> GetList()
        {
            var result = await _HttpClient.GetFromJsonAsync<List<MonHoc>>("api/MonHocs/");
            return result!;
        }

        public async Task<bool> Update(string id, MonHoc monHoc)
        {
            var result = await _HttpClient.PutAsJsonAsync($"api/MonHocs/{id}", monHoc);
            return result.IsSuccessStatusCode;
        }
    }
