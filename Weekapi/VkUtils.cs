using System.Collections.Generic;
using Vk.Api;

namespace Weekapi
{
    public static class VkUtils
    {
        public static List<Message> GetMessageHistory(Api vkApi, int userId)
        {
            int offset = 0;
            bool iterate = true;
			
            var messageHistory = new List<Message>();

            while (iterate)
            {
                var messages = vkApi.Messages.GetHistory(userId.ToString(), offset, 200, 1);
                if (messages.Length == 0)
                    iterate = false;
                else
                {
                    messageHistory.AddRange(messages);
                    offset += 200;
					
                    System.Threading.Thread.Sleep(1000);
                }
            }

            return messageHistory;
        }
        
        public static List<Dialog> GetDialogs(Api vkApi)
        {
            int offset = 0;
            bool iterate = true;
			
            var dialogList = new List<Dialog>();

            while (iterate)
            {
                var dialogs = vkApi.Messages.GetDialogs(offset, 200);
                if (dialogs.Length == 0)
                    iterate = false;
                else
                {
                    dialogList.AddRange(dialogs);
                    offset += 200;
					
                    System.Threading.Thread.Sleep(1000);
                }
            }

            return dialogList;
        }
    }
}