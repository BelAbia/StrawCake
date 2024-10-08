using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using System.Security.Cryptography.X509Certificates;

namespace StrawCake.Dominio.RavenDB
{
    public static class DocumentStoreHolder
    {
        static X509Certificate2 clientCertificate = new X509Certificate2(ConstantesDoRaven.CAMINHO_CERTIFICADO_RAVEN);

        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Certificate = clientCertificate,
                    Urls = new[] { ConstantesDoRaven.URL_RAVEN_CLIENT, ConstantesDoRaven.URL_RAVEN_DOCKER },
                    Database = ConstantesDoRaven.NOME_BASE_STRAWCAKE,
                    Conventions = ObterPadroesDoBanco()
                };

                return store.Initialize();
            });

        private static DocumentConventions ObterPadroesDoBanco()
        {
            return new DocumentConventions
            {
                MaxNumberOfRequestsPerSession = 30,
                UseOptimisticConcurrency = true,
                SaveEnumsAsIntegers = true,
                IdentityPartsSeparator = '-'
            };
        }

        public static IDocumentStore Store => LazyStore.Value;
    }
}
