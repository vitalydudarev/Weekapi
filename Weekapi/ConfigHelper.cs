using System;
using System.IO;
using Common;
using Newtonsoft.Json;

namespace Weekapi
{
    public static class ConfigHelper
    {
        private const string ConfigFile = "config.json";
        
        public static Config ReadConfig()
        {
            var configExists = File.Exists(ConfigFile);
            if (!configExists)
                throw new Exception($"Configuration file {ConfigFile} not found.");

            var configContents = File.ReadAllText(ConfigFile);
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new ContractResolver() };
			
            return JsonConvert.DeserializeObject<Config>(configContents, jsonSettings);
        }
    }
}