using static StrawCake.Dominio.CoberturaEnum;
using static StrawCake.Dominio.MassaEnum;
using static StrawCake.Dominio.RecheioEnum;
using static StrawCake.Dominio.TamanhoEnum;

namespace StrawCake.Dominio
{
    public class Bolo
    {
        public string? Id { get; set; }
        public Massa Massa { get; set; }
        public Recheio Recheio { get; set; }
        public Cobertura Cobertura { get; set; }
        public Tamanho Tamanho { get; set; }
        public double Valor { get; set; }
    }
}