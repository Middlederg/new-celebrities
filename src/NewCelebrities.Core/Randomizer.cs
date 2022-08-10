namespace NewCelebrities.Core
{
    public static class Randomizer
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);
        private static int GetRandomNumber(int inf, int sup) => random.Next(inf, sup + 1);
        public static T GetRandomItem<T>(this IEnumerable<T> lista)
        {
            if (lista == null || !lista.Any())
                return default;

            return lista.ElementAt(GetRandomNumber(0, lista.Count() - 1));
        }
        public static IEnumerable<T> RandomizeList<T>(this List<T> lista)
        {
            List<T> mazoAuxiliar = new List<T>();

            int pasadas = lista.Count();
            for (int i = 0; i < pasadas; i++)
            {
                int pos = random.Next(0, lista.Count);
                T o = lista[pos];
                mazoAuxiliar.Add(o);
                lista.Remove(o);
            }
            return mazoAuxiliar;
        }
    }
}
