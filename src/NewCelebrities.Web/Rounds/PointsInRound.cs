using Microsoft.Extensions.Localization;
using NewCelebrities.Core;

namespace NewCelebrities.Web.Translations
{
    public class PointsInRoundTranslator
    {
        private readonly IStringLocalizer<PointsInRoundTranslator> stringLocalizer;
        public PointsInRoundTranslator(IStringLocalizer<PointsInRoundTranslator> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
        }

        public string Text(TurnSummary turnSummary)
        {
            if (turnSummary.Points == 0) return stringLocalizer["NoPoints"];

            if (turnSummary.Points == 1) return stringLocalizer["OnePoint"];

            return ((string)stringLocalizer["Points"]).Replace("{n}", turnSummary.Points.ToString());
        }

        public string Message(TurnSummary turnSummary)
        {
            return turnSummary.Points switch
            {
                <= 5 => stringLocalizer[$"Points{turnSummary.Points}"],
                > 5 => stringLocalizer["ManyPoints"]
            };
        }
    }
}
