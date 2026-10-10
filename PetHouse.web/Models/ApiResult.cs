namespace PetHouse.web.Models
{
    public class ApiResult<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public string? Error { get; init; }

        public static ApiResult<T> Ok(T? data = default) =>
            new() { Success = true, Data = data };

        public static ApiResult<T> Fail(string error) =>
            new() { Success = false, Error = error };
    }
}