using System.Linq;

namespace NewCelebrities.Core
{
    public abstract class Round
    {
        public int Number { get; }
        public abstract bool NextAllowed { get; }
        public abstract bool UnlimitedAnswersPerConcept { get; }

        protected Round(int number)
        {
            Number = number;
        }
    }
}
