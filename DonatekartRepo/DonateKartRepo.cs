using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DonatekartModel;
using System.Collections.Generic;
using System.IO;

namespace DonatekartRepo
{
    public class DonateKartRepo : IDonateKartRepo
    {
        IConfiguration configuration;
        private static readonly HttpClient client = new HttpClient();
        public DonateKartRepo(IConfiguration iconfiguration)
        {
            configuration = iconfiguration;
        }



        public string getResponse(string config)
        {
            
            string stringUrl = configuration.GetSection(config).Value;

            return ProcessRepositories(stringUrl).Result;
        }



        private static async Task<string> ProcessRepositories(string url)
        {
            var streamTask = await client.GetStreamAsync(url);
             //await JsonSerializer.DeserializeAsync<List<T>>(streamTask);
            StreamReader reader = new StreamReader(streamTask);
            return reader.ReadToEnd();
        }

    }
}
