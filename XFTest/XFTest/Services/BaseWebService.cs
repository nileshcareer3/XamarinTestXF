using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Acr.UserDialogs;
using ModernHttpClient;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using RestSharp;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.HttpClient.Impl;
using XFTest.Comman;
using XFTest.Utility;

namespace XFTest.Services
{
    public class BaseWebService
    {
        RestClient _restClient;
        public static string MyWayUrl = "http://localhost:5002/GetCarWashDetails";
        public static string MyWayUrlAndroid = "http://10.0.2.2:5002/GetCarWashDetails";

        #region Available Constructors
        public BaseWebService()
        {
            string BaseUrl = string.Empty;
            if(CrossDeviceInfo.Current.Platform.ToString().ToLower() == Platform.iOS.ToString().ToLower())
            {
                BaseUrl = MyWayUrl;
            }
            else
            {
                BaseUrl = MyWayUrlAndroid;
            }
            _restClient = new RestClient(BaseUrl)
            {
                IgnoreResponseStatusCode = true,
                Timeout = TimeSpan.FromMinutes(5),
                HttpClientFactory = new BVClientFactory(),  
            };
            ServicePointManager.ServerCertificateValidationCallback +=(sender, certificate, chain, sslPolicyErrors) => true;
        }
        #endregion

        #region Execute request
        public async Task<T> ExecuteGet<T>(RestRequest request, bool isTokenToBeSent, bool isTempTokenToBeSent = false) where T : new()
        {
            request.Method = Method.GET;

            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);

         
            if (CommonUtility.IsConnectedToInternet())
            {
                try
                {
                 
                    var response = await _restClient.Execute(request);

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            {
                                JsonSerializerSettings settings = new JsonSerializerSettings
                                {
                                    NullValueHandling = NullValueHandling.Ignore
                                };
                                return JsonConvert.DeserializeObject<T>(response.Content, settings);
                            }

                        case HttpStatusCode.Gone:
                            {
                                UserDialogs.Instance.Alert(response.StatusDescription + " " + response.StatusCode);
                            }
                            break;

                        case HttpStatusCode.Unauthorized:
                            {
                             
                                UserDialogs.Instance.Alert(response.StatusDescription + " " + response.StatusCode);
                            }
                            break;

                        case HttpStatusCode.InternalServerError:
                            {
                                UserDialogs.Instance.Alert(response.StatusDescription + " " + response.StatusCode);
                            }
                            break;

                        case HttpStatusCode.BadRequest:
                            {
                                UserDialogs.Instance.Alert(response.StatusDescription + " " + response.StatusCode);
                            }
                            break;

                        case HttpStatusCode.NotFound:
                            {
                                //TODO: Need to handle
                            }
                            break;
                        case HttpStatusCode.RequestTimeout:
                            {
                                UserDialogs.Instance.Alert(response.StatusDescription + " " + response.StatusCode);
                            }
                            break;

                    }
                    UserDialogs.Instance.Alert(response.StatusDescription, AppResources.BtnTitle_Ok);
                }
                catch (WebException ex)
                {
                    UserDialogs.Instance.Alert(ex.Message, null, AppResources.BtnTitle_Ok);
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert(ex.Message, null, AppResources.BtnTitle_Ok);
                }
            }
            else
            {
                UserDialogs.Instance.Alert(AppResources.Msg_InternetConnectionNotAvailable, null, AppResources.BtnTitle_Ok);
            }
            return default;
        }
        #endregion


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }


    #region
    public class BVClientFactory : DefaultHttpClientFactory
    {
        protected override HttpMessageHandler CreateMessageHandler(IRestClient client)
        {
            return new NativeMessageHandler();
        }
    }

    #endregion
}