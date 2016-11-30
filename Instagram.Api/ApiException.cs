using System;

namespace Instagram.Api
{
	public class ApiException : Exception
	{
		public int Code { get; set; }
		public string ErrorType { get; set; }
		public string ErrorMessage { get; set; }

		public ApiException(string errorMessage, string errorType, int code)
		{
			ErrorType = errorType;
			ErrorMessage = errorMessage;
			Code = code;
		}
	}
}
