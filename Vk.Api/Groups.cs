using System.Collections.Generic;

namespace Vk.Api
{
	public class Groups
	{
		private readonly RequestExecutor _requestExecutor;

		public Groups(RequestExecutor requestExecutor)
		{
			_requestExecutor = requestExecutor;
		}

		public Group[] Search(string q)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "q", q }
			};

			return _requestExecutor.Execute<Response<Group>>("groups.search", parameters).Items;
		}
	}
}