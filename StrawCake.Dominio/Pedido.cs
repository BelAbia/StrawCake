using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio
{
    public class Pedido
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public Status Status { get; set; }
        public string Descricao { get; set; }
    }
}