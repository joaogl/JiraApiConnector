using JiraApiClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient
{

    public abstract class JiraAPIBase
    {

        private JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Converters = new[] { new StringEnumConverter() { CamelCaseText = true, AllowIntegerValues = true } }
        };

        public string APIUser { get; private set; }
        public string APIPassword { get; private set; }
        public string APIURL { get; private set; }
        public string AuthToken { get; private set; }

        public AuthToken AuthInfo { get; private set; }

        public JiraAPIBase(string url, string user, string password)
        {
            this.APIURL = url;
            this.APIUser = user;
            this.APIPassword = password;

            JiraAuthorize();
        }

        public JiraAPIBase(string url, string authToken)
        {
            this.APIURL = url;
            this.AuthToken = authToken;
        }

        public JiraAPIBase(string apiURL)
        {
            this.APIURL = apiURL;
        }

        protected string ConstructAPIURL(string url)
        {
            if (!url.StartsWith("http"))
            {
                if (url.StartsWith("/") && APIURL.EndsWith("/"))
                    url = url.Substring(1);
                if (!url.StartsWith("/") && !APIURL.EndsWith("/"))
                    url = "/" + url;
                if (!url.StartsWith("http"))
                    url = APIURL + url;
            }
            return url;
        }

        public virtual ApiResult<T> Get<T>(string url, bool retry = true, bool withAuthorize = true)
        {
            url = ConstructAPIURL(url);

            ApiResult<T> result = new ApiResult<T>();

            try
            {
                using (JiraWebClient wc = new JiraWebClient(AuthToken))
                {
                    string jsonResponse = wc.DownloadString(new Uri(url));

                    if (!string.IsNullOrEmpty(jsonResponse))
                    {
                        if (typeof(T) == typeof(byte[]))
                        {
                            result.Result = (T)Convert.ChangeType(Convert.FromBase64String(jsonResponse), typeof(T));
                        }
                        else
                        {
                            result.Result = JsonConvert.DeserializeObject<T>(jsonResponse, jsonSettings);
                        }
                    }
                }
            }
            catch (WebException e)
            {
                if (!retry)
                {
                    Console.Error.WriteLine(string.Format("API: Exception GET {0} - Exception: {1}", url, e));
                    result.Exception = e;
                }
                else
                {
                    Console.Error.WriteLine(string.Format("API: Exception GET {0}. Trying again... - Exception: {1}", url, e));

                    withAuthorize = ValidateResponse(e);

                    if (withAuthorize)
                    {
                        JiraAuthorize();
                    }

                    return Get<T>(url, false);
                }
            }

            return result;
        }

        public virtual ApiResult<T> Post<T>(string url, object data, bool retry = true, bool withAuthorize = true)
        {
            url = ConstructAPIURL(url);

            ApiResult<T> result = new ApiResult<T>();

            try
            {
                using (JiraWebClient wc = new JiraWebClient(AuthToken))
                {
                    string jsonResponse = wc.UploadString(new Uri(url), JsonConvert.SerializeObject(data, jsonSettings));

                    if (!string.IsNullOrEmpty(jsonResponse))
                    {
                        result.Result = JsonConvert.DeserializeObject<T>(jsonResponse, jsonSettings);
                    }
                }
            }
            catch (WebException e)
            {
                if (!retry)
                {
                    Console.Error.WriteLine(string.Format("API: Exception POST {0} -  Exception: {1}", url, e));
                    result.Exception = e;
                }
                else
                {
                    Console.Error.WriteLine(string.Format("API: Exception POST {0}. Trying again...  - Exception: {1} ", url, e));

                    withAuthorize = ValidateResponse(e);

                    if (withAuthorize)
                    {
                        JiraAuthorize();
                    }
                    return Post<T>(url, data, false);
                }
            }

            return result;
        }

        private bool ValidateResponse(WebException e)
        {
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;

                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        return true;
                }
            }

            return false;
        }

        public virtual ApiResult<T> Put<T>(string url, object data, bool retry = true, bool withAuthorize = true)
        {
            url = ConstructAPIURL(url);

            ApiResult<T> result = new ApiResult<T>();

            try
            {
                using (JiraWebClient wc = new JiraWebClient(AuthToken))
                {
                    string jsonResponse = wc.UploadString(new Uri(url), "PUT", JsonConvert.SerializeObject(data, jsonSettings));


                    if (!string.IsNullOrEmpty(jsonResponse))
                    {
                        result.Result = JsonConvert.DeserializeObject<T>(jsonResponse, jsonSettings);
                    }
                }
            }
            catch (WebException e)
            {
                if (!retry)
                {
                    Console.Error.WriteLine(string.Format("API: Exception POST {0} -  Exception: {1}", url, e));
                    result.Exception = e;
                }
                else
                {
                    Console.Error.WriteLine(string.Format("API: Exception POST {0}. Trying again...  - Exception: {1} ", url, e));

                    withAuthorize = ValidateResponse(e);

                    if (withAuthorize)
                    {
                        JiraAuthorize();
                    }
                    return Post<T>(url, data, false);
                }
            }

            return result;
        }

        public virtual ApiResult<T> Delete<T>(string url, object data = null, bool retry = true, bool withAuthorize = true)
        {
            url = ConstructAPIURL(url);

            ApiResult<T> result = new ApiResult<T>();

            try
            {
                using (JiraWebClient wc = new JiraWebClient(AuthToken))
                {
                    string jsonResponse = wc.UploadString(new Uri(url), "DELETE", JsonConvert.SerializeObject(data, jsonSettings));

                    if (!string.IsNullOrEmpty(jsonResponse))
                    {
                        result.Result = JsonConvert.DeserializeObject<T>(jsonResponse, jsonSettings);
                    }
                }
            }
            catch (WebException e)
            {
                if (!retry)
                {
                    Console.Error.WriteLine(string.Format("API: Exception DELETE {0} - Exception: {1}", url, e));
                    result.Exception = e;
                }
                else
                {
                    Console.Error.WriteLine(string.Format("API: Exception DELETE {0}. Trying again... - Exception: {1}", url, e));

                    withAuthorize = ValidateResponse(e);

                    if (withAuthorize)
                    {
                        JiraAuthorize();
                    }

                    return Delete<T>(url, data, false);
                }
            }

            return result;
        }

        private AuthToken GetAuthorizationToken(string username, string password)
        {
            object body = new
            {
                Username = username,
                Password = password
            };

            ApiResult<AuthToken> result = Post<AuthToken>("/auth/latest/session", body, false);

            if (result.Exception != null)
                throw result.Exception;

            return result.Result;
        }

        public virtual void JiraAuthorize()
        {
            AuthInfo = GetAuthorizationToken(APIUser, APIPassword);

            AuthToken = AuthInfo.Session.Value;
        }

    }

}
