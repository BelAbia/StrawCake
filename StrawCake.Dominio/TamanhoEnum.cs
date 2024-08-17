using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio
{
    public class TamanhoEnum
    {
        public enum Tamanho
        {
            [Description("Pequeno")]
            Pequeno,
            [Description("Médio")]
            Medio,
            [Description("Grande")]
            Grande
        }
    }
}
