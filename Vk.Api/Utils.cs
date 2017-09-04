using System.Collections.Generic;

namespace Vk.Api
{
    public static class Utils
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
    }
}