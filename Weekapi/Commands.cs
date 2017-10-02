using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Vk.Api;

namespace Weekapi
{
    public static class Commands
    {
        private static readonly Lazy<Config> ConfigLazy = new Lazy<Config>(ConfigHelper.ReadConfig);
		
        public static void VkDumpMessages(string folder, int[] userIds)
        {
            var config = ConfigLazy.Value;
            var api = new Api(config.VkAccessToken, config.VkApiVersion, config.VkUri);
			
            var dateTimeStr = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                .Replace(":", "_")
                .Replace("-", "_")
                .Replace(" ", "_")
                .Replace("/", "_");

            foreach (var userId in userIds)
            {
                var messageHistory = VkUtils.GetMessageHistory(api, userId);
                var serialized = JsonConvert.SerializeObject(messageHistory, Formatting.Indented);
                var fileName = $@"{userId}_{dateTimeStr}.txt";
                var path = Path.Combine(folder, fileName);
                File.WriteAllText(path, serialized);
            }
        }
    }
}