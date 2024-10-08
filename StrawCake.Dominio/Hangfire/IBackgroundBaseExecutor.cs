using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio.Hangfire
{
    public interface IBackgroundBaseExecutor
    {
        void Executar(Bolo bolo);
    }
}
