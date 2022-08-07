using NewCelebrities.Core.File;

namespace NewCelebrities.Core
{
    public class Categories
    {
        //private const string separator = "";

        private readonly IEnumerable<string> categories;

        public Categories(params string[] categories)
        {
            this.categories = categories.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public override string ToString() => string.Join(", ", categories);

        public string ToPrimitive() => string.Join(Writer.Separator, categories);
    }
}