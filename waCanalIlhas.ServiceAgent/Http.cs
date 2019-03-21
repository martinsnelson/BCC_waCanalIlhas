using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using waCanalIlhas.DTO.Request;
using waCanalIlhas.DTO.Response;

namespace waCanalIlhas.ServiceAgent
{
    public static class Http
    {
        public static IConfiguration Configuration { get; set; }

        public static T Get<T>(string pAction) where T : BaseResponse
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string serverAdress = Configuration["waCalendarUrl"];

            string url = string.Format("{0}{1}", serverAdress, pAction);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 600000;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public static T Post<T>(string pAction, BaseRequest request) where T : BaseResponse
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string serverAdress = Configuration["waCalendarUrl"];

            string url = string.Format("{0}{1}", serverAdress, pAction);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 600000;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var jObject = JsonConvert.SerializeObject(request);
                streamWriter.Write(jObject);
                streamWriter.Flush();
                streamWriter.Close();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
        }
    }
}
