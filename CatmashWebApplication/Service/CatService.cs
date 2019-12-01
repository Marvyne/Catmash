using CatmashWebApplication.Interfaces;
using CatmashWebApplication.Models;
using CatmashWebApplication.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatmashWebApplication.Service
{
    public class CatService : ICatService
    {
        HttpClient _client = new HttpClient();
        public Cat Create(Cat cat)
        {
            var result = _client.PostAsJsonAsync(ApplicationSettings.WebApiUrl, cat).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Cat>(result.Content.ReadAsStringAsync().Result);
            return null;
        }

        public HttpStatusCode Delete(string id)
        {
            var result = _client.DeleteAsync(ApplicationSettings.WebApiUrl + id).Result;
            return result.StatusCode;
        }

        public Cat Get(string id)
        {
            var result = _client.GetAsync(ApplicationSettings.WebApiUrl + id).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Cat>(result.Content.ReadAsStringAsync().Result);
            return null;
        }

        public List<Cat> GetAll()
        {
            var result = _client.GetAsync(ApplicationSettings.WebApiUrl).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Cat>>(result.Content.ReadAsStringAsync().Result);
            return null;
        }

        public Cat Updated(Cat cat)
        {
            var result = _client.PutAsJsonAsync(ApplicationSettings.WebApiUrl + cat.Id, cat).Result;

            if (result.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Cat>(result.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
