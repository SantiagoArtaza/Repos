using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Final.Http
{
    public class ClienteSingleton
    {
        private static ClienteSingleton instance;
        private HttpClient client;

        public static ClienteSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ClienteSingleton();
            }
            return instance;
        }

        public ClienteSingleton()
        {
            client = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            var result = await client.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> PostAsync(string url, string data)
        {
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var result =  await client.PostAsync(url, content);
            var response = "";
            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();
            return response;
        }

        //public async Task<string> GetAsync(string fecha, string hora, int matricula)
        //{
        //    StringContent content = new StringContent(fecha, Encoding.UTF8, "application/json");
        //    var result = await client.GetAsync(fecha, hora, matricula);
        //    var response = "";
        //    if (result.IsSuccessStatusCode)
        //        response = await result.Content.ReadAsStringAsync();
        //    return response;


        //}
    }
}
