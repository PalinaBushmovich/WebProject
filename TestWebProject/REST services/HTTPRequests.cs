using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestWebProject.REST
{
    public static class HTTPrequests
    {

        private static Dictionary<string, string> headers = new Dictionary<string, string> { { "Authorization", "Basic Y2xlcmtmdWxsOlRob21zb24hMA==" } };

        public static HttpWebRequest ExecutePostRequest(string Url, string json)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json";
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            return request;
        }

        internal static string GetResponseHeader(object p, object headerName)
        {
            throw new NotImplementedException();
        }

        public static HttpWebRequest ExecuteGetRequest(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
        }

        public static string GetResponseBody(HttpWebRequest executeRequest)
        {
            string bodyResponse;
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                using (StreamReader myStreamReader = new StreamReader(response.GetResponseStream()))
                {
                    bodyResponse = myStreamReader.ReadToEnd();
                }
                return bodyResponse;
            }
        }

        public static string GetResponseHeader(HttpWebRequest executeRequest, string headerName)
        {
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                return response.Headers.Get(headerName);
            }
        }

        public static HttpStatusCode GetResponseStatusCode(HttpWebRequest executeRequest)
        {
            using (HttpWebResponse response = (HttpWebResponse)executeRequest.GetResponse())
            {
                return response.StatusCode;
            }
        }
    }
}
