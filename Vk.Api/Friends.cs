using System.Collections.Generic;

namespace Vk.Api
{
	public class Friends
	{
		private readonly RequestExecutor _requestExecutor;

		public Friends(RequestExecutor requestExecutor)
		{
			_requestExecutor = requestExecutor;
		}

		public Friend[] Get(string userId)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "user_id", userId },
				{ "fields", "last_seen" }
			};

			return _requestExecutor.Execute<Response<Friend>>("friends.get", parameters).Items;
		}
	}
}