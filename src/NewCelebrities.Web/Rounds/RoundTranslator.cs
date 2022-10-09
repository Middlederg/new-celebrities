using Microsoft.Extensions.Localization;
using NewCelebrities.Core;

namespace NewCelebrities.Web.Translations
{
    public class RoundTranslator
    {
        private readonly IStringLocalizer<RoundTranslator> stringLocalizer;
        public RoundTranslator(IStringLocalizer<RoundTranslator> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }

        public string Text(Round round) => ((string)stringLocalizer[$"Round"]).Replace("{n}", round.Number.ToString());
        public string Title(Round round) => stringLocalizer[$"Title{round.Number}"];
        public string Description(Round round) => stringLocalizer[$"Description{round.Number}"];
        public string NextConceptInstructions(Round round) => round.NextAllowed ? stringLocalizer["SkipAllowed"] : stringLocalizer["SkipNotAllowed"];
        public string AnswerLimitationInstructions(Round round) => round.UnlimitedAnswersPerConcept ? stringLocalizer["UnlimitedAnswers"] : stringLocalizer["LimitedAnswers"];
    }
}
