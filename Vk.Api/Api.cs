namespace Vk.Api
{
	public class Api
	{
		private const string Uri = @"https://api.vk.com/method/";
		private readonly string _accessToken;
		private readonly string _apiVersion;

		private Audio _audio;
		private Friends _friends;
		private Groups _groups;

		public Audio Audio
		{
			get { return _audio ?? (_audio = new Audio(_accessToken, _apiVersion, Uri)); }
		}

		public Friends Friends
		{
			get { return _friends ?? (_friends = new Friends(_accessToken, _apiVersion, Uri)); }
		}

		public Groups Groups
		{
			get { return _groups ?? (_groups = new Groups(_accessToken, _apiVersion, Uri)); }
		}

		public Api(string accessToken, string apiVersion)
		{
			_accessToken = accessToken;
			_apiVersion = apiVersion;
		}
	}
}