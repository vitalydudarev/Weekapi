using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
        
        public static void VkDumpMessageHistory(string folder)
        {
            var config = ConfigLazy.Value;
            var api = new Api(config.VkAccessToken, config.VkApiVersion, config.VkUri);
            
            var dialogs = VkUtils.GetDialogs(api);
            var userIds = dialogs.Select(a => a.Message.UserId).ToList();

            var messages = new List<Message>();

            foreach (var userId in userIds)
            {
                var messageHistory = VkUtils.GetMessageHistory(api, userId);
                messages.AddRange(messageHistory);
            }

            var dateTimeStr = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                .Replace(":", "_")
                .Replace("-", "_")
                .Replace(" ", "_")
                .Replace("/", "_");
            
            var serialized = JsonConvert.SerializeObject(messages, Formatting.Indented);
            var fileName = $@"all_messages_{dateTimeStr}.txt";
            var path = Path.Combine(folder, fileName);
            File.WriteAllText(path, serialized);
        }
    }
}