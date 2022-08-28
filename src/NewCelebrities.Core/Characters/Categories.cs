using NewCelebrities.Core.File;

namespace NewCelebrities.Core
{
    public class Categories
    {
        public IEnumerable<string> CategoryList { get; }

        public Categories(params string[] categories)
        {
            CategoryList = categories.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public override string ToString() => string.Join(", ", CategoryList);

        public bool Has(string category)
        {
            return CategoryList.Contains(category, StringComparer.InvariantCultureIgnoreCase);
        }

        public string ToPrimitive() => string.Join(Writer.Separator, CategoryList);
    }
}