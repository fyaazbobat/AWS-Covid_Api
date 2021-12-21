using Client_Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Core.BLL
{
    public class ApiHelper
    {

       static string BaseUrl = "https://localhost:44309/api/Covid/";

        public static async Task<List<Covid_Dto>> GetAllData()
        {
            using var client = new HttpClient();
            var res = await client.GetAsync(BaseUrl);
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Covid_Dto>>(data);

        }
        public static async Task<bool> InsertCovidData(Covid_Dto model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var Jsondata = new StringContent(json, Encoding.UTF8, "application/json"); 
            using var res = await client.PostAsync(BaseUrl, Jsondata);
            if (!res.IsSuccessStatusCode) return false;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return true;

        }
        public static async Task<Covid_Dto> GetById(int Id)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Id);
            var Jsondata = new StringContent(json, Encoding.UTF8, "application/json");
            using var res = await client.GetAsync(BaseUrl+ Id);
            if (!res.IsSuccessStatusCode) return null;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Covid_Dto>(data);
          ;

        }
        public static async Task<bool> Update(int Id, Covid_Dto model)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            var Jsondata = new StringContent(json, Encoding.UTF8, "application/json");
            using var res = await client.PutAsync(BaseUrl + Id, Jsondata);
            if (!res.IsSuccessStatusCode) return false;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return true;
            

        }

        public static async Task<bool> DeleteCovid(int Id)
        {
            using var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Id);
            var Jsondata = new StringContent(json, Encoding.UTF8, "application/json");
            using var res = await client.DeleteAsync(BaseUrl+Id);
            if (!res.IsSuccessStatusCode) return false;
            using var content = res.Content;
            var data = await content.ReadAsStringAsync();
            return true;

        }

    }
}
