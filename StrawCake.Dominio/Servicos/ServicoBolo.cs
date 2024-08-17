using Raven.Client.Documents.Session;
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
        public Bolo Adicionar(Bolo bolo)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(bolo);
                session.SaveChanges();
            }

            return bolo;
        } 
        
        public List<Bolo> ObterTodos()
        {
            using IDocumentSession session = DocumentStoreHolder.Store.OpenSession();
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
