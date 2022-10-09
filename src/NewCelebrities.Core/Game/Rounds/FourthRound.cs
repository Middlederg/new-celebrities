namespace NewCelebrities.Core
{
    public class FourthRound : Round
    {
        public override bool NextAllowed => true;
        public override bool UnlimitedAnswersPerConcept => false;


        public FourthRound() : base(number: 4) { }
    }
}
