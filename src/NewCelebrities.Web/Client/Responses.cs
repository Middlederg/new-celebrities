namespace NewCelebrities.Web
{
    public class Responses
    {
        public List<IResponse> ResponseList { get; }

        public Responses(params IResponse[] responses)
        {
            ResponseList = responses.ToList();
        }

        public bool HasError => ResponseList.Where(x => x is not null).Any(x => x.HasError);
        public bool Success => !HasError;
    }
}
