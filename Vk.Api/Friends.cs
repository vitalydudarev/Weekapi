using System.Collections.Generic;
using Common;

namespace Vk.Api
{
	public class Friends
	{
		private readonly string _accessToken;
		private readonly string _apiVersion;
		private readonly string _uri;

		public Friends(string accessToken, string apiVersion, string uri)
		{
			_accessToken = accessToken;
			_apiVersion = apiVersion;
			_uri = uri;
		}

		public void Get(string userId)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "user_id", userId },
				{ "v", _apiVersion },
				{ "access_token", _accessToken }
			};

			var client = new Client(_uri + "friends.get");
			var request = new GetRequest(parameters);
			var response = client.Send(request);
			var responseParser = new ResponseParser();
			var resp = responseParser.Parse<Response>(response);
		}

		public class Response
		{
			public int Count { get; set; }
			public Item[] Items { get; set; }
		}

		public struct Item
		{
			public int Id { get; set; }
			public int OwnerId { get; set; }
			public string Artist { get; set; }
			public string Title { get; set; }
			public int Duration { get; set; }
			public string Url { get; set; }
			public int LyricsId { get; set; }
			public int GenreId { get; set; }
		}
	}
}