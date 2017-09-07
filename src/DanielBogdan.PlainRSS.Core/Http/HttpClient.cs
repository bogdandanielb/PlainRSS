using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace DanielBogdan.PlainRSS.Core.Http
{
    /// <summary>
    /// Http Client class
    /// </summary>
    public class HttpClient
    {

        public Proxy Proxy { get; set; }
        public CookieContainer Cookies { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }
        public int Timeout { get; set; } = 60000;
        public bool FollowRedirects { get; set; } = true;
        public bool CanRefreshRefererWithLatestUrl { get; set; } = true;

        public HttpClient()
        {

        }

        public HttpClient(Proxy proxy, CookieContainer cookies, string userAgent, int timeout)
        {
            this.Proxy = proxy;
            this.Cookies = cookies;
            this.Referer = Referer;
            this.UserAgent = userAgent;
            this.Timeout = timeout;
        }

        public HttpClient(Proxy proxy, CookieContainer cookies, string userAgent, int timeout, bool followRedirects)
        {
            this.Proxy = proxy;
            this.Cookies = cookies;
            this.Referer = Referer;
            this.UserAgent = userAgent;
            this.Timeout = timeout;
            this.FollowRedirects = followRedirects;
        }


        /// <summary>
        /// Http GET request to a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string Get(string url, string referer = null)
        {

            HttpWebRequest wrequest = null;
            HttpWebResponse wresponse = null;


            try
            {
                wrequest = (HttpWebRequest)WebRequest.Create(url);
                wrequest.Accept = "*/*";
                wrequest.Method = "GET";
                wrequest.Timeout = Timeout;
                wrequest.ReadWriteTimeout = Timeout;
                wrequest.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                wrequest.KeepAlive = true;
                wrequest.AllowAutoRedirect = FollowRedirects;

                if (Cookies != null)
                    wrequest.CookieContainer = Cookies;
                if (!string.IsNullOrEmpty(referer))
                    wrequest.Referer = referer;
                else if (CanRefreshRefererWithLatestUrl && !string.IsNullOrEmpty(this.Referer))
                    wrequest.Referer = this.Referer;

                if (Proxy != null)
                {
                    var wp = new WebProxy(Proxy.Ip + ":" + Proxy.Port);
                    if (!string.IsNullOrEmpty(Proxy.Username))
                        wp.Credentials = new NetworkCredential(Proxy.Username, Proxy.Password);
                    wrequest.Proxy = wp;
                }
                if (!string.IsNullOrEmpty(UserAgent))
                    wrequest.UserAgent = UserAgent;


                wresponse = (HttpWebResponse)wrequest.GetResponse();
                var responseStream = wresponse.GetResponseStream();
                if (wresponse.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (wresponse.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);



                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();


            }
            catch (Exception ex)
            {
                Trace.WriteLine("Http.Get: " + ex.Message);
                return null;
            }
            finally
            {
                if (wresponse != null)
                    wresponse.Close();

                if (CanRefreshRefererWithLatestUrl)
                    this.Referer = url;
            }
        }


        /// <summary>
        /// Http POST request to a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string Post(string url, string postData, string referer = null)
        {

            HttpWebRequest wrequest = null;
            HttpWebResponse wresponse = null;


            try
            {

                var data = postData;
                var bdata = Encoding.UTF8.GetBytes(data);

                wrequest = (HttpWebRequest)WebRequest.Create(url);
                wrequest.Accept = "*/*";
                wrequest.Method = "POST";
                wrequest.Timeout = Timeout;
                wrequest.ReadWriteTimeout = Timeout;
                wrequest.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                wrequest.AllowAutoRedirect = FollowRedirects;
                wrequest.KeepAlive = true;

                if (Cookies != null)
                    wrequest.CookieContainer = Cookies;
                if (!string.IsNullOrEmpty(referer))
                    wrequest.Referer = referer;
                else if (CanRefreshRefererWithLatestUrl && !string.IsNullOrEmpty(this.Referer))
                    wrequest.Referer = this.Referer;

                if (Proxy != null)
                {
                    var wp = new WebProxy(Proxy.Ip + ":" + Proxy.Port);
                    if (!string.IsNullOrEmpty(Proxy.Username))
                        wp.Credentials = new NetworkCredential(Proxy.Username, Proxy.Password);
                    wrequest.Proxy = wp;
                }
                if (!string.IsNullOrEmpty(UserAgent))
                    wrequest.UserAgent = UserAgent;


                wrequest.ContentType = "application/x-www-form-urlencoded";
                wrequest.ContentLength = bdata.Length;

                Stream newStream;
                newStream = wrequest.GetRequestStream();
                newStream.Write(bdata, 0, bdata.Length);
                newStream.Close();

                wresponse = (HttpWebResponse)wrequest.GetResponse();
                var responseStream = wresponse.GetResponseStream();
                if (wresponse.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (wresponse.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);



                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Http.Post: " + ex.Message);
                return null;
            }
            finally
            {
                if (wresponse != null)
                    wresponse.Close();

                if (CanRefreshRefererWithLatestUrl)
                    this.Referer = url;
            }
        }



        /// <summary>
        /// Http POST multipart/form-data request to a given URL 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formData"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string PostMultipart(string url, IDictionary<string, string> formData, string referer = null)
        {

            HttpWebRequest wrequest = null;
            HttpWebResponse wresponse = null;
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            try
            {

                wrequest = (HttpWebRequest)WebRequest.Create(url);
                wrequest.Accept = "*/*";
                wrequest.Method = "POST";
                wrequest.ContentType = "multipart/form-data; boundary=" + boundary;
                wrequest.Timeout = Timeout;
                wrequest.ReadWriteTimeout = Timeout;
                wrequest.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                wrequest.AllowAutoRedirect = FollowRedirects;
                wrequest.KeepAlive = true;

                if (Cookies != null)
                    wrequest.CookieContainer = Cookies;
                if (!string.IsNullOrEmpty(referer))
                    wrequest.Referer = referer;
                else if (CanRefreshRefererWithLatestUrl && !string.IsNullOrEmpty(this.Referer))
                    wrequest.Referer = this.Referer;

                if (Proxy != null)
                {
                    var wp = new WebProxy(Proxy.Ip + ":" + Proxy.Port);
                    if (!string.IsNullOrEmpty(Proxy.Username))
                        wp.Credentials = new NetworkCredential(Proxy.Username, Proxy.Password);
                    wrequest.Proxy = wp;
                }
                if (!string.IsNullOrEmpty(UserAgent))
                    wrequest.UserAgent = UserAgent;



                // Build up the post message header
                var sb = new StringBuilder();
                if (formData != null)
                {
                    foreach (var key in formData.Keys)
                    {
                        sb.Append("--");
                        sb.Append(boundary);
                        sb.Append("\r\n");
                        sb.Append("Content-Disposition: form-data; name=\"" + key + "\"\r\n");
                        sb.Append("\r\n");
                        sb.Append(formData[key]);
                        sb.Append("\r\n");
                    }
                }

                sb.Append("--" + boundary + "--\r\n");

                var postHeader = sb.ToString();
                var postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);


                wrequest.ContentLength = postHeaderBytes.Length;

                var requestStream = wrequest.GetRequestStream();
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                requestStream.Close();

                wresponse = (HttpWebResponse)wrequest.GetResponse();
                var responseStream = wresponse.GetResponseStream();
                if (wresponse.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (wresponse.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);



                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Http.PostMultipart: " + ex.Message);
                return null;
            }
            finally
            {
                if (wresponse != null)
                    wresponse.Close();

                if (CanRefreshRefererWithLatestUrl)
                    this.Referer = url;
            }

        }




        /// <summary>
        /// Upload file to a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formData"></param>
        /// <param name="filePath"></param>
        /// <param name="fileFieldName"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string Upload(string url, IDictionary<string, string> formData, string filePath, string fileFieldName, string referer = null)
        {


            FileStream fileStream = null;


            try
            {


                fileStream = new FileStream(filePath,
                                           FileMode.Open, FileAccess.Read);

                return Upload(url, formData, fileStream, filePath, fileFieldName, referer);

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Http.Upload: " + ex.Message);
                return null;
            }
            finally
            {

                if (fileStream != null)
                    fileStream.Close();
            }

        }



        /// <summary>
        /// Upload stream content to a given URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formData"></param>
        /// <param name="stream"></param>
        /// <param name="filePath"></param>
        /// <param name="fileFieldName"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public string Upload(string url, IDictionary<string, string> formData, Stream stream, string filePath, string fileFieldName, string referer = null)
        {

            HttpWebRequest wrequest = null;
            HttpWebResponse wresponse = null;

            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");

            try
            {

                wrequest = (HttpWebRequest)WebRequest.Create(url);
                wrequest.ContentType = "multipart/form-data; boundary=" + boundary;
                wrequest.Method = "POST";
                wrequest.Accept = "*/*";
                wrequest.Timeout = Timeout;
                wrequest.ReadWriteTimeout = Timeout;
                wrequest.Headers[HttpRequestHeader.AcceptLanguage] = "en-us";
                wrequest.AllowAutoRedirect = FollowRedirects;
                wrequest.KeepAlive = true;

                if (Cookies != null)
                    wrequest.CookieContainer = Cookies;

                if (!string.IsNullOrEmpty(referer))
                    wrequest.Referer = referer;
                else if (CanRefreshRefererWithLatestUrl && !string.IsNullOrEmpty(this.Referer))
                    wrequest.Referer = this.Referer;

                if (Proxy != null)
                {
                    var wp = new WebProxy(Proxy.Ip + ":" + Proxy.Port);
                    if (!string.IsNullOrEmpty(Proxy.Username))
                        wp.Credentials = new NetworkCredential(Proxy.Username, Proxy.Password);
                    wrequest.Proxy = wp;
                }
                if (!string.IsNullOrEmpty(UserAgent))
                    wrequest.UserAgent = UserAgent;



                // Build up the post message header
                var sb = new StringBuilder();
                if (formData != null)
                {
                    foreach (var key in formData.Keys)
                    {
                        sb.Append("--");
                        sb.Append(boundary);
                        sb.Append("\r\n");
                        sb.Append("Content-Disposition: form-data; name=\"" + key + "\"\r\n");
                        sb.Append("\r\n");
                        sb.Append(formData[key]);
                        sb.Append("\r\n");
                    }
                }
                sb.Append("--");
                sb.Append(boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"" + fileFieldName + "\"; ");
                sb.Append("filename=\"" + Path.GetFileName(filePath) + "\"");
                sb.Append("\r\n");
                sb.Append("Content-Type: " + MimeTypeResolver.Resolve(Path.GetExtension(filePath)) + "\r\n");
                sb.Append("\r\n");


                var postHeader = sb.ToString();
                var postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);

                // Build the trailing boundary string as a byte array
                // ensuring the boundary appears on a line by itself
                var boundaryBytes =
                       Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");


                var length = postHeaderBytes.Length + stream.Length +
                                                       boundaryBytes.Length;
                wrequest.ContentLength = length;

                var requestStream = wrequest.GetRequestStream();

                // Write out our post header
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);

                // Write out the file contents
                var buffer = new byte[checked((uint)Math.Min(4096,
                                         (int)stream.Length))];
                var bytesRead = 0;
                stream.Position = 0;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    requestStream.Write(buffer, 0, bytesRead);

                // Write out the trailing boundary
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                requestStream.Close();

                wresponse = (HttpWebResponse)wrequest.GetResponse();
                var responseStream = wresponse.GetResponseStream();
                if (wresponse.ContentEncoding.ToLower().Contains("gzip"))
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                else if (wresponse.ContentEncoding.ToLower().Contains("deflate"))
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);



                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Http.Upload: " + ex.Message);
                return null;
            }
            finally
            {
                if (wresponse != null)
                    wresponse.Close();

                if (stream != null)
                    stream.Close();

                if (CanRefreshRefererWithLatestUrl)
                    this.Referer = url;
            }

        }





        //Fix CookieContainer bug
        //1. All subdomains should send back all parent cookies (ie GET sub.domain.com should send cookies from  sub.domain.com, .domain.com and domain.com) - the BUG: it does not send back any parent domain.com cookies (parent not starting with dot)
        //2. All cookies under the same domain, with or without dot should be sent back (ie GET domain.com should send cookies from .domain.com and domain.com) - the BUG: it does not send back .domain.com (current domain starting with dot)
        //BUG FIX - we need two versions for both situations - with and without dot for each domain
        //According to Microsoft this has been fixed in .NET 4.0 - untested
        public static void BugFix_CookieDomain(CookieContainer cookieContainer)
        {
            var containerType = typeof(CookieContainer);
            var table = (Hashtable)containerType.InvokeMember("m_domainTable",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.GetField |
            System.Reflection.BindingFlags.Instance,
            null,
            cookieContainer,
            new object[] { });
            var keys = new ArrayList(table.Keys);
            foreach (string keyObj in keys)
            {
                if (!table.ContainsKey(keyObj)) //if they were removed below already
                    continue;

                var key = (keyObj as string);
                if (key[0] == '.')
                {
                    var newKey = key.Remove(0, 1);
                    table[newKey] = table[keyObj];
                    //table.Remove(keyObj); //do NOT delete, we need both dot and without dot versions
                }
            }
        }

    }
}
