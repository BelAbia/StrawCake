using Hangfire;
using Raven.Client.Documents.Session;
using StrawCake.Dominio.RavenDB;

namespace StrawCake.Dominio.Hangfire
{
    public class ExecutorDeCriacaoDeBolo
    {
        public void ExecutarCriacaoDeBolo(Bolo bolo)
        {
            try
            {
                //Criar um pedido aqui?

                using var session = ControladorDeDocumentos.Store.OpenSession(ConstantesDoRaven.NOME_BASE_STRAWCAKE);
                //AlterarStatus(session, bolo);
                BackgroundJob.Schedule(() => AlterarStatus(session, bolo), TimeSpan.FromMinutes(1));
                session.SaveChanges();

            }
            catch (Exception ex)
            {
            }
        }

        public void AlterarStatus(IDocumentSession session, Bolo bolo)
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
    }
}
