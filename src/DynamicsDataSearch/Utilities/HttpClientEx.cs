﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DynamicsDataSearch.Utilities
{
    public static class HttpClientEx
    {
        public static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = content,
            };

            return client.SendAsync(request);
        }

        public static HttpResponseMessage Patch(this HttpClient client, string requestUri, HttpContent content)
        {
            return AsyncHelpers.RunSync(() => client.PatchAsync(requestUri, content));
        }
    }
}
