using System.Collections.Generic;

namespace Vk.Api
{
	public class Audio
	{
		private readonly RequestExecutor _requestExecutor;

		public Audio(RequestExecutor requestExecutor)
		{
			_requestExecutor = requestExecutor;
		}

		public Track[] Get(string ownerId)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "owner_id", ownerId }
			};

			return _requestExecutor.Execute<Response<Track>>("audio.get", parameters).Items;
		}

		public Track[] Search(string q)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "q", q },
				{ "auto_complete", "1" }
			};

			return _requestExecutor.Execute<Response<Track>>("audio.search", parameters).Items;
		}
	}
}