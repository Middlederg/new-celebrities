namespace NewCelebrities.Web
{
    public interface IResponse
    {
        string Title { get; }
        string Description { get; }
        bool HasError { get; }
        bool Success { get; }
    }
}
