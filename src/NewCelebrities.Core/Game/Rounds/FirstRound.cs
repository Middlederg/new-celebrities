namespace NewCelebrities.Core
{
    public class FirstRound : Round
    {
        public override bool NextAllowed => false;
        public override bool UnlimitedAnswersPerConcept => true;

        public FirstRound() : base(number: 1) { }
    }
}
