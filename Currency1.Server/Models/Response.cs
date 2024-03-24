namespace Currency1.Server.Models
{
    public class Response<T>
    {
        public string[]? Errors { get; set; }

        public T Value { get; set; }

        public Response(T value) { 
            Value = value;
        }

        public Response(T value, string[] error)
        {
            Value = value;
            Errors = error;
        }
    }
}
