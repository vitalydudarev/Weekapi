using System.Collections.Generic;

namespace Vk.Api
{
    public class Messages : Base
    {
        public Messages(string accessToken, string apiVersion, string uri) : base(accessToken, apiVersion, uri)
        {
        }
        
        public Dialog[] GetDialogs()
        {
            return Execute<Response<Dialog>>("messages.getDialogs", new Dictionary<string, string>()).Items;
        }
        
        public Message[] Get()
        {
            return Execute<Response<Message>>("messages.get", new Dictionary<string, string>()).Items;
        }

        public Message[] GetHistory(string userId, int offset, int count, int rev = 0)
        {
            var parameters = new Dictionary<string, string>
            {
                { "user_id", userId },
                { "offset", offset.ToString() },
                { "count", count.ToString() },
                { "rev", rev.ToString() }
            };
            
            return Execute<Response<Message>>("messages.getHistory", parameters).Items;
        }
    }
}