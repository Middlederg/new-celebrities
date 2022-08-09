using System;
using System.Collections.Generic;
using System.Text;

namespace NewCelebrities.Core
{
    public class PointsInRound
    {
        public int Number { get; }

        public PointsInRound(int numero)
        {
            Number = numero;
        }

        public override string ToString()
        {
            if (Number == 0)
                return "Ninguna tarjeta acertada";

            if (Number == 1)
                return "Una tarjeta acertada";

            return $"{Number} tarjetas acertadas";
        }

        public string Message()
        {
            if (Number <= 0)
                return "Podéis hacerlo mejor";

            if (Number == 1)
                return "Pasito a pasito";

            if (Number == 2)
                return "¡No está mal!";

            if (Number == 3)
                return "¡Bastante bien!";

            if (Number == 4)
                return "¡Un equipo super compenetrado!";

            if (Number == 5)
                return "¡Increible!";

            return "La victoria está a un paso";
        }
    }
}
