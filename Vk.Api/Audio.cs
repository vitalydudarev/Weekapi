using System.Collections.Generic;

namespace Vk.Api
{
	public class Audio : Base
	{
		public Audio(string accessToken, string apiVersion, string uri) : base(accessToken, apiVersion, uri)
		{
		}

		public Track[] Get(string ownerId)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "owner_id", ownerId }
			};

			return Execute<Response<Track>>("audio.get", parameters).Items;
		}

		public Track[] Search(string q)
		{
			var parameters = new Dictionary<string, string>
			{
				{ "q", q },
				{ "auto_complete", "1" }
			};

			return Execute<Response<Track>>("audio.search", parameters).Items;
		}
	}
}