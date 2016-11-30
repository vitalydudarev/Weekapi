using Common;

namespace Instagram.Api
{
	public class ResponseParser
	{
		private readonly JsonParser _parser;

		public ResponseParser()
		{
			_parser = new JsonParser();
		}

		public ApiResponse<T> Parse<T>(string inputString) where T : class
		{
			return new ApiResponse<T>
			{
				Meta = ParseInternal<Meta>(inputString, "meta"),
				Pagination = ParseInternal<Pagination>(inputString, "pagination"),
				Data = ParseInternal<T>(inputString, "data")
			};
		}

		private T ParseInternal<T>(string inputString, string key) where T : class
		{
			string token;

			return _parser.TryGetToken(inputString, key, out token) ? _parser.Parse<T>(token) : null;
		}
	}
}
