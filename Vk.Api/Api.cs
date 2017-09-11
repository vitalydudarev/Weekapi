namespace Vk.Api
{
	public class Api
	{
		private readonly RequestExecutor _requestExecutor;

		private Audios _audios;
		private Friends _friends;
		private Groups _groups;
		private Messages _messages;
		
		public Audios Audios => _audios ?? (_audios = new Audios(_requestExecutor));

		public Friends Friends => _friends ?? (_friends = new Friends(_requestExecutor));

		public Groups Groups => _groups ?? (_groups = new Groups(_requestExecutor));

		public Messages Messages => _messages ?? (_messages = new Messages(_requestExecutor));

		public Api(string accessToken, string apiVersion, string uri)
		{
			_requestExecutor = new RequestExecutor(accessToken, apiVersion, uri);
		}
	}
}