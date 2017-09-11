using System.Collections.Generic;

namespace Vk.Api
{
	public class Audios
	{
		private readonly RequestExecutor _requestExecutor;

		public Audios(RequestExecutor requestExecutor)
		{
			_requestExecutor = requestExecutor;
		}

		public Audio[] Get(string ownerId)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "owner_id", ownerId }
			};

			return _requestExecutor.Execute<Response<Audio>>("audio.get", parameters).Items;
		}

		public Audio[] Search(string q)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "q", q },
				{ "auto_complete", "1" }
			};

			return _requestExecutor.Execute<Response<Audio>>("audio.search", parameters).Items;
		}
	}
}