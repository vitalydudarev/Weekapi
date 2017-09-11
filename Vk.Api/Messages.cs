using System.Collections.Generic;

namespace Vk.Api
{
    public class Messages
    {
        private readonly RequestExecutor _requestExecutor;

        public Messages(RequestExecutor requestExecutor)
        {
            _requestExecutor = requestExecutor;
        }
        
        public Dialog[] GetDialogs()
        {
            return _requestExecutor.Execute<Response<Dialog>>("messages.getDialogs", new Dictionary<string, string>()).Items;
        }
        
        public Message[] Get()
        {
            return _requestExecutor.Execute<Response<Message>>("messages.get", new Dictionary<string, string>()).Items;
        }
        
        public string Response => _requestExecutor.ResponseSource;

        public Message[] GetHistory(string userId, int offset, int count, int rev = 0)
        {
            var parameters = new Dictionary<string, string>
            {
                { "user_id", userId },
                { "offset", offset.ToString() },
                { "count", count.ToString() },
                { "rev", rev.ToString() }
            };
            
            return _requestExecutor.Execute<Response<Message>>("messages.getHistory", parameters).Items;
        }
    }
}