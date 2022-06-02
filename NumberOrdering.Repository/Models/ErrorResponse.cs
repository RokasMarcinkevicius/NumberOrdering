namespace Compliance.AssociatedAccounts.Models
{
	public class ErrorResponse
    {
		public string ErrorCode { get; set; }
		public string Message { get; set; }

		/// <summary>
		/// ErrorResponse
		/// </summary>
		/// <param name="errorCode"></param>
		/// <param name="message"></param>
		public ErrorResponse(string errorCode, string message)
		{
			this.ErrorCode = errorCode;
			this.Message = message;
		}
	}
}

