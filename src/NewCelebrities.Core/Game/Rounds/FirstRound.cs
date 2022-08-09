namespace NewCelebrities.Core
{
    public class FirstRound : Round
    {
        public override string Description => "Describir el concepto pudiendo hablar con libertad, pero sin utilizar partes de la palabra o su traducción en otro idioma.";
        public override bool NextAllowed => false;
        public override bool UnlimitedAnswersPerConcept => true;

        public FirstRound() : base(number: 1) { }
    }
}
