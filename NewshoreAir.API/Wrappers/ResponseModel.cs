namespace NewshoreAir.API.Wrappers
{
	public class ResponseModel<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }

		public ResponseModel()
		{

		}

		public ResponseModel(T data, string message = null)
		{
			Success = true;
			Message = message;

		}

		public ResponseModel(string message = null)
		{
			Success = false;
			Message = message;

		}
	}
}
