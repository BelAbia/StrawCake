using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio
{
    public class StatusEnum
    {
        public enum Status
        {
            [Description ("Finalizado")]
            Finalizado,
            [Description("Em Andamento")]
            EmAndamento,
            [Description("Erro")]
            Erro
        }
    }
}
