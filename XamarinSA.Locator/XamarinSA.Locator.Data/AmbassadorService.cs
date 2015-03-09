using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using XamarinSA.Locator.Data.Extensions;
using System.Net;
using System.Diagnostics;
using XamarinSA.Locator.Data.Models;
using System.Net.Http;

namespace XamarinSA.Locator.Data
{
	public static class AmbassadorService
	{
#if DEBUG
        private const String HOST_NAME = "https://10.0.1.9:44301/api";
        private const String ALL_AMBASSADORS = "values";
        private const String DETA_AMBASSADOR = "values/{0}";
#else
        private const String HOST_NAME = "https://rest-xamarinambassador.azurewebsites.net/api";
        private const String ALL_AMBASSADORS = "/values/";
        private const String DETA_AMBASSADOR = "/values/{0}";
#endif
        private static async Task<T> SendData<T>(string endpoint, HttpMethod method,
            IEnumerable<KeyValuePair<string, string>> content = null) where T : class
        {
            //create default for result
            T returnResult = null;

            HttpClient client = null;
            try
            {
                //create REST client
                client = new HttpClient();
                client.BaseAddress = new Uri(HOST_NAME);
                //request json for smaller payloads
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                //set time out to just 15 seconds
                client.Timeout = new TimeSpan(0, 0, 15);

                HttpResponseMessage result = null;

                FormUrlEncodedContent data = null;
                if (content != null)
                    data = new FormUrlEncodedContent(content);

                //determine how to send the data
                if (method == HttpMethod.Get)
                    result = await client.GetAsync(endpoint);

                if (method == HttpMethod.Put)
                    result = await client.PutAsync(endpoint, data);

                if (method == HttpMethod.Delete)
                    result = await client.DeleteAsync(endpoint);

                if (method == HttpMethod.Post)
                    result = await client.PostAsync(endpoint, data);

                if (result != null)
                {
                    //check if result was good.
                    if (result.IsSuccessStatusCode
                        && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //ok to process
                        var json = result.Content.ReadAsStringAsync().Result;
                        //assign payload to json value.
                        returnResult = JsonConvert.DeserializeObject<T>(json);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error fetching data: " + ex.Message);
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return returnResult;
        }
		
        public static void FetchAmbassadorsAsync(Action<ICollection<Ambassador>> callback) {
            SendData<ICollection<Ambassador>>(ALL_AMBASSADORS, HttpMethod.Get,
                null).ContinueWith((completed) =>
                {
                    if (!completed.IsFaulted)
                        callback(completed.Result);
                    else
                        callback(null);
                }, TaskScheduler.FromCurrentSynchronizationContext());
		}

        public static void FetchUniversityAsync(Action<University> callback)
        {
            SendData<University>(DETA_AMBASSADOR, HttpMethod.Get,
                null).ContinueWith((completed) =>
                {
                    if (!completed.IsFaulted)
                        callback(completed.Result);
                    else
                        callback(null);
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

	}
}

