using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumeAPI
{
    public class Consume
    {

        public async Task<object> getDataAsync(string _link, string endpoint)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_link);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(endpoint);

                if (Res.IsSuccessStatusCode)
                {

                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    var results = JsonConvert.DeserializeObject<List<object>>(EmpResponse);

                    return results;
                }
            }

            return null;
        }
    }
}
