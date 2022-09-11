namespace NewCelebrities.Web.Client
{
    public class OkResponse : IResponse
    {
        public string Title => "";
        public string Description => "";

        public bool HasError => false;
        public bool Success => true;

        public override string ToString() => Title;

        private OkResponse() { }

        public static OkResponse Build()
        {
            return new OkResponse();
        }
    }
}
