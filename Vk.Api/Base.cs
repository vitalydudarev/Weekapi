using System.Collections.Generic;
using Common;

namespace Vk.Api
{
	public abstract class Base
	{
		private readonly string _accessToken;
		private readonly string _apiVersion;
		private readonly string _uri;

		protected Base(string accessToken, string apiVersion, string uri)
		{
			_accessToken = accessToken;
			_apiVersion = apiVersion;
			_uri = uri;
		}

		protected T Execute<T>(string method, Dictionary<string, string> parameters) where T : class
		{
			var reqParameters = GetParameters(parameters);
			var client = new Client(_uri + method);
			var request = new GetRequest(reqParameters);
			var response = client.Send(request);
			var responseParser = new ResponseParser();
			return responseParser.Parse<T>(response);
		}

		private Dictionary<string, string> GetParameters(Dictionary<string, string> parameters)
		{
			parameters.Add("v", _apiVersion);
			parameters.Add("access_token", _accessToken);

			return parameters;
		}
	}
}