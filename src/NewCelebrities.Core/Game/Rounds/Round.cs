using System.Linq;

namespace NewCelebrities.Core
{
    public abstract class Round
    {
        public int Number { get; }
        public abstract string Description { get; }
        public abstract bool NextAllowed { get; }
        public abstract bool UnlimitedAnswersPerConcept { get; }

        protected Round(int number)
        {
            Number = number;
        }

        public override string ToString() => $"Round {Number}";
        public string NextConceptInstructions() => NextAllowed ? "You can skip cards" : "Cards can not be skipped until guessed";
        public string AnswerLimitationInstructions() => UnlimitedAnswersPerConcept ? "Unlimited answers per card" : "Just one answer option per card";
    }
}
