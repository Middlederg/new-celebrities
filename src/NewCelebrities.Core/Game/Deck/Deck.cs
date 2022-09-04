using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class Deck
    {
        public const int Min = 10;
        public const int Max = 100;
        public const int Default = 40;

        private readonly List<DeckItem> items;
        public IEnumerable<Character> Characters => items.Select(x => x.Character).ToList();

        internal Deck(IEnumerable<Character> characters)
        {
            Ensure.NotNull(characters);
            Ensure.That<ArgumentOutOfRangeException>(characters.Count() >= Min && characters.Count() <= Max,
             $"Can not create a deck with {characters.Count()} concepts");

            items = characters.Select(x => new DeckItem(x)).ToList();
        }

        public void Guess() => VisibleItem.Guess();

        public bool IsFinished => items.All(x => x.IsGuessed);
        public int GuessedCount => items.Count(x => x.IsGuessed);
        public int PendingCount => items.Count(x => !x.IsGuessed);
        public int Count => items.Count();
        public DeckItem VisibleItem => items.First(x => !x.IsGuessed);
        public void Skip()
        {
            var item = new DeckItem(VisibleItem.Character);
            items.Remove(VisibleItem);
            items.Add(item);
        }

        public void Reset()
        {
            foreach (var item in items)
            {
                item.Reset();
            }
        }
    }
}
