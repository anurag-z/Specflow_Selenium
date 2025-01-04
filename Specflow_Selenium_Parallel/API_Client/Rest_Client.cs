using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
namespace Specflow_Selenium_Parallel.API_Client
{
    public interface IRest_Client 
    {
        RestResponse Get (string url) ;
        RestResponse Post(string url, object data, Dictionary<string, string> headers=null);
        RestResponse Put(string url, object data, Dictionary<string, string> headers=null);
        RestResponse Delete(string url, Dictionary<string, string> headers=null);


    }
    public class Rest_Client : IRest_Client,IDisposable
    {
        private readonly IRestClient _httpClient;
        public Rest_Client() 
        {
         _httpClient = new RestClient();
        }
        //public Rest_Client(RestClient restclient)
        //{
        //    _httpClient = restclient;
        //}
        public RestResponse Delete(string url, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_httpClient != null) { 
            _httpClient.Dispose();
            }
        }

        public RestResponse Get(string url)
        {
            var request = new RestRequest(url, Method.Get);
            var response = _httpClient.Execute(request);

            return response;
        }

        public RestResponse Post (string url, object data, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(url, Method.Post);
            if (headers != null)
            {
                request.AddHeaders(headers);
            }
            // Method.POST for POST request
            request.AddJsonBody(data); // Add JSON body for POST request

            return _httpClient.Execute(request);
           // return JsonConvert.DeserializeObject<T>(response.Content!)!;
        }

        public RestResponse Put(string url, object data, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(url, Method.Put); // Method.POST for POST request
            request.AddJsonBody(data); // Add JSON body for POST request

            return _httpClient.Execute(request);
           // return JsonConvert.DeserializeObject<T>(response.Content!)!;
        }

    }
}
