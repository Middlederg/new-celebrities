using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class DeckItem
    {
        public Guid Id { get; }

        public Character Character { get; }

        public bool IsGuessed { get; private set; }
        public void Guess() => IsGuessed = true;
        public void Reset() => IsGuessed = false;

        public DeckItem(Character character)
        {
            Id = Guid.NewGuid();
            Character = character;
            IsGuessed = false;
        }

        public override string ToString() => Character.ToString();
    }
}
