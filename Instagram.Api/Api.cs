using System.Collections.Generic;
using Common;

namespace Instagram.Api
{
	public class Api
    {
        private readonly string _accessToken;
        private readonly string _uri;
        private readonly ResponseParser _responseParser;

		private Users _users;

		public Users Users { get { return _users ?? (_users = new Users(_accessToken, _uri)); } }

        public Api(string accessToken)
        {
            _accessToken = accessToken;
            _uri = @"https://api.instagram.com/v1/";
            _responseParser = new ResponseParser();
        }

        public UserInfo GetSelf()
        {
            var uri = _uri + "users/self/?access_token=" + _accessToken;

            return Execute<UserInfo>(uri);
        }

        public string GetSelfFeed()
        {
            var client = new Client(_uri + "users/self/feed?access_token=" + _accessToken);
            return client.Send(new GetRequest());
        }

        public List<User> GetUsersFollowedBy(string userId)
        {
            var uri = _uri + "users/" + userId + "/followed-by?access_token=" + _accessToken;

            return ExecuteCollection<User>(uri);
        }

        private List<T> ExecuteCollection<T>(string uri) where T : class
        {
            var result = new List<T>();

            while (!string.IsNullOrEmpty(uri))
            {
                var client = new Client(uri);
                var response = client.Send(new GetRequest());
                var apiResponse = _responseParser.Parse<T[]>(response);
                var meta = apiResponse.Meta;
                if (meta.Code != 200)
                    throw new ApiException(meta.ErrorMessage, meta.ErrorType, meta.Code);

                result.AddRange(apiResponse.Data);

                uri = apiResponse.Pagination != null ? apiResponse.Pagination.NextUrl : null;
            }

            return result;
        }

        private T Execute<T>(string uri) where T : class
        {
            var result = new List<T>();

            while (!string.IsNullOrEmpty(uri))
            {
                var client = new Client(uri);
                var response = client.Send(new GetRequest());
                var apiResponse = _responseParser.Parse<T>(response);
                var meta = apiResponse.Meta;
                if (meta.Code != 200)
                    throw new ApiException(meta.ErrorMessage, meta.ErrorType, meta.Code);

                result.Add(apiResponse.Data);

                uri = apiResponse.Pagination != null ? apiResponse.Pagination.NextUrl : null;
            }

            return result[0];
        }
    }
}
