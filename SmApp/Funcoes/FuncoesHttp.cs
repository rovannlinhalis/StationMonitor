using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmApp.Funcoes
{
    public static class FuncoesHttp
    {
        public static string HttpRquest(HttpRequestMethods method, string url, string postData, string token)
        {
            //using (WebClient wb = new WebClient() { Encoding = Encoding.UTF8})
            //{

            //    wb.UploadData()
            //    wb.DownloadString(url);
            //}

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            byte[] data = Encoding.UTF8.GetBytes(postData);
            //request.Headers["api-token"] = token;
            request.Method = method.ToString();// "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }

    public enum HttpRequestMethods
    {
        GET,
        POST,
        PUT
    }
}
