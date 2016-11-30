using Common;
using System.Collections.Generic;

namespace Instagram.Api
{
	public class Users
	{
		private readonly string _uri;
		private readonly string _accessToken;
		private readonly ResponseParser _responseParser;

		public Users(string accessToken, string uri)
		{
			_accessToken = accessToken;
			_uri = uri;
			_responseParser = new ResponseParser();
		}

		public UserInfo GetSelfUser()
		{
			var uri = _uri + "users/self?access_token=" + _accessToken;

			return Execute<UserInfo>(uri);
		}

		public UserInfo GetUser(string userId)
		{
			var uri = _uri + "users/" + userId + "?access_token=" + _accessToken;

			return Execute<UserInfo>(uri);
		}

		public List<Media> GetSelfRecentMedia()
		{
			var uri = _uri + "users/self/media/recent?access_token=" + _accessToken;

			return ExecuteCollection<Media>(uri);
		}

		public List<Media> GetUserRecentMedia(string userId)
		{
			var uri = _uri + "users/" + userId + "/media/recent?access_token=" + _accessToken;

			return ExecuteCollection<Media>(uri);
		}

		public List<Media> GetSelfLikedMedia()
		{
			var uri = _uri + "users/self/media/liked?access_token=" + _accessToken;

			return ExecuteCollection<Media>(uri);
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
