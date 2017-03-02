﻿using DynamicsDataSearch.Configuration;
using DynamicsDataSearch.Models;
using DynamicsDataSearch.Utilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Net;
using Newtonsoft.Json.Linq;

namespace DynamicsDataSearch.Services
{
    public class DynamicsSearchService : IDynamicsSearchService
    {
        private HttpAuthorisationConfig Config;

        public DynamicsSearchService(IOptions<HttpAuthorisationConfig> authConfig)
        {
            this.Config = authConfig.Value;
        }

        public string GetJsonById(DynamicsSearch searchParams)
        {
            var request = new HttpRequest(this.Config);
            var response = request.DoRequest($"{this.Config.ApiUrl}{searchParams.entity}({searchParams.id})", null, "application/json", "GET");

            if (response.Successful)
            {
                return response.Content;
            }

            return null;
        }

        public TEntity GetById<TEntity>(DynamicsSearch searchParams)
        {
            var request = new HttpRequest(this.Config);
            var response = request.DoRequest($"{this.Config.ApiUrl}{searchParams.entity}({searchParams.id})", null, "application/json", "GET");

            if (response.Successful)
            {
                return (TEntity)JsonConvert.DeserializeObject(response.Content, typeof(TEntity));
            }

            return default(TEntity);
        }

        public List<TEntity> Search<TEntity>(DynamicsSearch searchParams)
        {
            var filter = !string.IsNullOrWhiteSpace(searchParams.filter) ? $"&$filter={WebUtility.UrlEncode(searchParams.filter)}" : string.Empty;
            var url = $"{this.Config.ApiUrl}{searchParams.entity}?$select={searchParams.fields}{filter}";

            var request = new HttpRequest(this.Config);
            var response = request.DoRequest(url, null, "application/json", "GET");

            var result = new List<TEntity>();
            if (response.Successful)
            {
                var odataResult = JObject.Parse(response.Content);
                JToken array = null;
                odataResult.TryGetValue("value", out array);

                result.AddRange((TEntity[])JsonConvert.DeserializeObject(array.ToString(), typeof(TEntity[])));
            }

            return result;
        }

        public string Search(DynamicsSearch searchParams)
        {
            var filter = !string.IsNullOrWhiteSpace(searchParams.filter) ? $"&$filter={WebUtility.UrlEncode(searchParams.filter)}" : string.Empty;
            var url = $"{this.Config.ApiUrl}{searchParams.entity}?$select={searchParams.fields}{filter}";

            var request = new HttpRequest(this.Config);
            var response = request.DoRequest(url, null, "application/json", "GET");

            return response.Successful ? response.Content : null;
        }
    }
}
