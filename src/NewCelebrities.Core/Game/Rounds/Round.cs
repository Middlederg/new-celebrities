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
        public string NextConceptInstructions() => NextAllowed ? "Se puede pasar a la siguiente tarjeta si no la adivinais" : "No se puede pasar a la siguiente tarjeta hasta adivinar la actual";
        public string AnswerLimitationInstructions() => UnlimitedAnswersPerConcept ? "Respuestas ilimitadas por tarjeta" : "Solo una respuesta por tarjeta";
    }
}
