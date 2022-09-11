namespace NewCelebrities.Web.Client
{
    public class MessageResponse : IResponse
    {
        private MessageModel messageModel;

        public string Title => messageModel.Title;
        public string Description => messageModel.Description ?? "";

        public bool HasError => true;
        public bool Success => false;

        public override string ToString() => Title;

        private MessageResponse() { }

        public static MessageResponse Build(string title, string description = null)
        {
            var response = new MessageResponse
            {
                messageModel = new MessageModel()
                {
                    Title = title,
                    Description = description
                }
            };
            return response;
        }
    }
}
