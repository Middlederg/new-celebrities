namespace NewCelebrities.Core
{
    public class SecondRound : Round
    {
        public override string Description => "Solo una palabra para describir el concepto";
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;

        public SecondRound() : base(number: 2) { }
    }
}
