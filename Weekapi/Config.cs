using System;

namespace Weekapi
{
    public class Config
    {
        public string VkAccessToken { get; set; }
        public string VkApiVersion { get; set; }
        public string VkUri { get; set; }

        public void CheckValid()
        {
            if (string.IsNullOrEmpty(VkAccessToken))
                throw new Exception("VK Acces Token is not defined.");
            
            if (string.IsNullOrEmpty(VkApiVersion))
                throw new Exception("VK API Version is not defined.");
            
            if (string.IsNullOrEmpty(VkUri))
                throw new Exception("VK Uri is not defined.");
        }
    }
}