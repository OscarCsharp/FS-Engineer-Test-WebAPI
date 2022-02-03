using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Model;

namespace WebAPI.Service
{
    public class ApiConsume : IApiConsume
    {
        private IConfiguration configuration;
        public ApiConsume(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public async Task<Object> getPeople()
        {

            string _swap = configuration.GetValue<string>("swap");
            _swap = _swap.Trim();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_swap);
                client.DefaultRequestHeaders.Clear();

                string endpoint = "/api/people";
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(endpoint.Trim());

                if (res.IsSuccessStatusCode)
                {

                    string contentResults = res.Content.ReadAsStringAsync().Result;
                    People result = JsonConvert.DeserializeObject<People>(contentResults);

                    return result.results;
                }
            }
            return null;

        }

        public async Task<List<string>> Jokes()
        {
            string _chuck = configuration.GetValue<string>("chuck");
            _chuck = _chuck.Trim();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_chuck);
                client.DefaultRequestHeaders.Clear();

                string endpoint = "/jokes/categories";
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(endpoint);

                if (res.IsSuccessStatusCode)
                {

                    string contentResults = res.Content.ReadAsStringAsync().Result ;
                    var result = JsonConvert.DeserializeObject<List<string>>(contentResults);

                    return result;
                }
            }
            return null;

        }

        public async Task<People> Person(string person)
        {
            string _swap = configuration.GetValue<string>("swap");
            _swap = _swap.Trim();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_swap);
                client.DefaultRequestHeaders.Clear();
     
                string endpoint = "/api/people/?search=" + person;
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(endpoint);

                if (res.IsSuccessStatusCode)
                {

                    string contentResults = res.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<People>(contentResults);

                    return result;
                }
            }
            return null;
        }
    }
}
