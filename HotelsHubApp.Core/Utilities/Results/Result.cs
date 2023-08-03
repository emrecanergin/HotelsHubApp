namespace HotelsHubApp.Core.Utilities.Results
{
    public class Result<T> where T : class
    {
        public T Data { get; }
        public string Message { get; }

          
        public Result(T data, string message)
        {
            Data = data;
            Message = message;
        }
       
        public Result(T data)
        {
            Data = data;
        }
    }
}
