namespace NewCelebrities.Core
{
    public class SecondRound : Round
    {
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;

        public SecondRound() : base(number: 2) { }
    }
}
