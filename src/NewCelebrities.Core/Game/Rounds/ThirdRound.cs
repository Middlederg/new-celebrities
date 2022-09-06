namespace NewCelebrities.Core
{
    public class ThirdRound : Round
    {
        public override string Title => "Mimic / sound";
        public override string Description => "Mímica y sonidos para describir el concepto";
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;

        public ThirdRound() : base(number: 3) { }
    }
}
