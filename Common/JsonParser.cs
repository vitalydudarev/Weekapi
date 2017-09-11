using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Common
{
    public class JsonParser : IParser
    {
        private readonly JsonSerializerSettings _settings;

        public JsonParser()
        {
            _settings = new JsonSerializerSettings();
            _settings.ContractResolver = new ContractResolver();
        }

        public T Parse<T>(string inputString)
        {
            return JsonConvert.DeserializeObject<T>(inputString, _settings);
        }

        public string GetToken(string inputString, string key)
        {
            var token = JToken.Parse(inputString);
            return token.SelectToken(key).ToString();
        }

        public bool TryGetToken(string inputString, string key, out string token)
        {
            try
            {
                token = GetToken(inputString, key);
            }
            catch (Exception)
            {
                token = null;
                return false;
            }

            return true;
        }
    }

    public class ContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToLower();
        }
    }
}
