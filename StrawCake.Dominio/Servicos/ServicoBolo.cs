using Hangfire;
using Raven.Client.Documents.Session;
using StrawCake.Dominio.Hangfire;
using StrawCake.Dominio.RavenDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio.Servicos
{
    public class ServicoBolo
    {
        private readonly ExecutorDeCriacaoDeBolo _executorDeCriacaoDeBolo;
        public ServicoBolo(ExecutorDeCriacaoDeBolo executorDeCriacaoDeBolo)
        {
            _executorDeCriacaoDeBolo = executorDeCriacaoDeBolo;
        }

        public Bolo Adicionar(Bolo bolo)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                bolo.Status = Status.EmAndamento;
                session.Store(bolo);
            }

             
            _executorDeCriacaoDeBolo.ExecutarCriacaoDeBolo(bolo);
            //primeira muda o status para "em criação"
            //depois no enfileiramento tenta criar com sucesso, caso seja criado com sucesso mudar o status para "criado", se não mudar o status para erro

            return bolo;
        }

        public void AlterarStatusDoBolo(IDocumentSession session, Bolo bolo)
        {
            session.SaveChanges();
            session.Load<Bolo>(bolo.Id);

            if (bolo != null)
            {
                bolo.Status = Status.Finalizado;
            }
            else
            {
                bolo.Status = Status.Erro;
            }
        }


        public List<Bolo> ObterTodos()
        {
            using IDocumentSession session = DocumentStoreHolder.Store.OpenSession();
            BackgroundJob.Enqueue(() => Console.WriteLine("obtidos todos"));
            return session.Query<Bolo>().ToList();

        }

        public Bolo ObterPorId(string id)
        {
            using IDocumentSession session = DocumentStoreHolder.Store.OpenSession();
            return session.Load<Bolo>(id);
        }

        public void Atualizar(string id, Bolo bolo)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var boloDoBanco = session.Load<Bolo>(id);

                if (boloDoBanco == null)
                {
                    throw new NullReferenceException($"Bolo com id {bolo.Id} não encontrado.");
                }

                session.Store(bolo);
                session.SaveChanges();
            }
        }

        public void Remover(string id)
        {
            using IDocumentSession session = DocumentStoreHolder.Store.OpenSession();
            session.Delete(id);
            session.SaveChanges();
        }
    }
}
