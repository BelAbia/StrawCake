using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio
{
    public class MassaEnum
    {
        public enum Massa
        {
            [Description("Chocolate")]
            Chocolate,
            [Description("Morango")]
            Morango,
            [Description("Baunilha")]
            Baunilha,
            [Description("Cenoura")]
            Cenoura,
            [Description("Fubá")]
            Fuba,
            [Description("Abacaxi")]
            Abacaxi
        }
    }
}
