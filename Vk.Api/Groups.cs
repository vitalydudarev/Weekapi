using System.Collections.Generic;

namespace Vk.Api
{
	public class Groups : Base
	{
		public Groups(string accessToken, string apiVersion, string uri) : base(accessToken, apiVersion, uri)
		{
		}

		public Group[] Search(string q)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "q", q }
			};

			return Execute<Response<Group>>("groups.search", parameters).Items;
		}
	}
}