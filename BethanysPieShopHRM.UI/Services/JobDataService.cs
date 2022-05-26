using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BethanysPieShopHRM.UI.Interfaces;

namespace BethanysPieShopHRM.UI.Services
{
    public class JobDataService : IJobDataService
    {
        private readonly HttpClient _client;

        public JobDataService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _client.GetJsonAsync<Job[]>("jobs");
        }

        public async Task<Job> GetJobById(int jobId)
        {
            return await _client.GetJsonAsync<Job>($"jobs/{jobId}");
        }

        public async Task AddJob(Job newJob)
        {
            var ret = await _client.PostJsonAsync<Job>("jobs", newJob);
            //var dictionary = newJob.GetType().GetProperties()
            //    .ToDictionary(p => p.Name, p => p.GetValue(newJob).ToString());

            //var requestMessage = new HttpRequestMessage()
            //{
            //    Method = new HttpMethod("POST"),
            //    RequestUri = new Uri("https://localhost:5001/jobs"),
            //    Content = new FormUrlEncodedContent(dictionary)
            //};

            //requestMessage.Headers.Add("x-custom", "secretCode");

            //await _client.SendAsync(requestMessage);
        }

        public async Task UpdateJob(Job updatedJob)
        {
            await _client.PutJsonAsync("jobs", updatedJob);
        }

        public async Task DeleteJob(int jobId)
        {
            await _client.DeleteAsync($"jobs/{jobId}");
        }
    }
}
