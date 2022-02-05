namespace HotelsHubApp.Core.Utilities.Results
{
    public class Result<T> where T : class
    {
        public T Data { get; }
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success, string message) 
        {
            Message = message;
            Success = success;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public Result(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public Result(T data, bool success)
        {
            Data = data;
            Success = success;
        }
      
    }
}
