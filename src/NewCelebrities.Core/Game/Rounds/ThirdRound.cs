namespace NewCelebrities.Core
{
    public class ThirdRound : Round
    {
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;

        public ThirdRound() : base(number: 3) { }
    }
}
