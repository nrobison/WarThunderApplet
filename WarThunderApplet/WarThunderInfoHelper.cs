using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarThunderApplet
{
    
    public class WarThunderInfoHelper
    {
        private HttpClient _httpClient = new HttpClient();
        private const string baseUrl = "http://localhost:8111/";

        public async Task<bool> IsConnectedToWarThunder()
        {
            var webResponse = await _httpClient.GetAsync(baseUrl);
            if (webResponse == null || webResponse.StatusCode != HttpStatusCode.OK) return false;
            return true;
        }

        public async Task<Dictionary<string, string>> GetInfo(string url)
        {
            return
                   JsonConvert.DeserializeObject<Dictionary<string, string>>(await
                       _httpClient.GetStringAsync(baseUrl + url));

        }
       
        public async Task<Image> GetMap()
        {
            //Todo: Switch from webCLient to HttpClient if possible

            using (var webClient = new WebClient())
            {
                //Just to be safe we don't want unexpected Crashes
                try
                {
                    var stream = new MemoryStream(webClient.DownloadData(baseUrl + "map.img"));
                    return Image.FromStream(stream);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }



}
