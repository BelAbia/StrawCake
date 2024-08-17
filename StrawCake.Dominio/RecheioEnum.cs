using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio
{
    public class RecheioEnum
    {
        public enum Recheio {
            [Description("Nenhum")]
            Nenhum,
            [Description("Chocolate")]
            Chocolate,
            [Description("Morango")]
            Morango,
            [Description("Baunilha")]
            Baunilha,
            [Description("Abacaxi")]
            Abacaxi,
            [Description("chantilly")]
            chantilly,
            [Description("Ganache")]
            Ganache,
            [Description("Chocolate Branco")]
            ChocolateBranco,
        }
    }
}
