namespace NewCelebrities.Core
{
    public class FourthRound : Round
    {
        public override string Description => "Escenificar una posición, como si el jugador fuese una estatua, para describir el concepto";
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;

        public FourthRound() : base(number: 4) { }
    }
}
