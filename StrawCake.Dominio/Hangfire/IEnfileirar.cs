using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio.Hangfire
{
    public interface IEnfileirar
    {
        public void Enfileirar<T>(Bolo bolo)
        {
        }
    }
}
