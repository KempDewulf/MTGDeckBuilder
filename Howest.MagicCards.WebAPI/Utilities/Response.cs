namespace Howest.MagicCards.WebAPI.Utilities;

public class Response<T>
{
    public  T Data { get; set; }
    public bool Success { get; set; }
    public string[]? Errors { get; set; }
    public string Message { get; set; } = string.Empty;
    
    public Response(): this(default(T))
    {

    }
    
    public Response(T data)
    {
        Data = data;
        Success = true;
    }
}