using NewCelebrities.Core.File;
using NewCelebrities.Shared;
using System.Drawing;

namespace NewCelebrities.Core
{
    public class Time
    {
        private readonly int? bornYear;
        private readonly int? deathYear;
        private readonly int? birthMin;
        private readonly int? birthMax;
        private readonly int? deathMin;
        private readonly int? deathMax;
        private readonly FileAge? ageBirth;
        private readonly FileAge? ageDeath;

        public static Time FromDto(Shared.Time dto)
        {
            return new Time(bornYear: dto.BornYear,
                    deathYear: dto.DeathYear,
                    birthMin: dto.BirthMin,
                    birthMax: dto.BirthMax,
                    deathMin: dto.DeathMin,
                    deathMax: dto.DeathMax,
                    ageBirth: dto.AgeBirth,
                    ageDeath: dto.AgeDeath);
        }


        public Shared.Time ToDto()
        {
            return new Shared.Time()
            {
                BornYear = bornYear,
                DeathYear = deathYear,
                BirthMin= birthMin,
                BirthMax= birthMax,
                DeathMin= deathMin,
                DeathMax= deathMax,
                AgeBirth= ageBirth,
                AgeDeath= ageDeath
            };
        }

        public Time(int? bornYear, int? deathYear, int? birthMin, int? birthMax, int? deathMin, int? deathMax, FileAge? ageBirth, FileAge? ageDeath)
        {
            this.bornYear = bornYear;
            this.deathYear = deathYear;
            this.birthMin = birthMin;
            this.birthMax = birthMax;
            this.deathMin = deathMin;
            this.deathMax = deathMax;
            this.ageBirth = ageBirth;
            this.ageDeath = ageDeath;
        }

        public string Born
        {
            get
            {
                if (bornYear.HasValue)
                {
                    return bornYear.ToString();
                }

                if (birthMin.HasValue && birthMax.HasValue)
                {
                    return $"{birthMin}/{birthMax}";
                }

                return "?";
            }
        }

        public string Death
        {
            get
            {
                if (deathYear.HasValue)
                {
                    return deathYear.ToString();
                }

                if (deathMin.HasValue && deathMax.HasValue)
                {
                    return $"{deathMin}/{deathMax}";
                }

                return "Today";
            }
        }

        public Age Age
        {
            get
            {
                int? year = bornYear ?? birthMax ?? birthMin ?? null;
                return year switch
                {
                    null => Age.Unknown,
                    < 476 => Age.Ancient,
                    < 1453 => Age.Medieval,
                    < 1789 => Age.Modern,
                    _ => Age.Contemporary
                };
            }
        }

        public override string ToString() => $"{Born} - {Death}";

        public string ToPrimitive()
        {
            var items = new string[]
            {
                bornYear?.ToString() ?? "",
                deathYear?.ToString() ?? "",
                birthMin?.ToString() ?? "",
                birthMax?.ToString() ?? "",
                deathMin?.ToString() ?? "",
                deathMax?.ToString() ?? "",
                ageBirth.HasValue ? ((int)ageBirth).ToString() : "",
                ageDeath.HasValue ? ((int)ageDeath).ToString() : "",
            };
            return string.Join(Writer.Separator, items);
        }
    }
}