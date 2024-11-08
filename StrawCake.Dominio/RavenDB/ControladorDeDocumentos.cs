using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace StrawCake.Dominio.RavenDB
{
    public static class ControladorDeDocumentos
    {
        public static IDocumentStore Store => store.Value;

        public static readonly Lazy<IDocumentStore> store =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    //Certificate = clientCertificate,
                    Urls = new[] { /*Environment.GetEnvironmentVariable(ConstantesDoRaven.URL_RAVEN_CLIENT),*/ Environment.GetEnvironmentVariable(ConstantesDoRaven.URL_RAVEN_DOCKER) },
                    Database = ConstantesDoRaven.NOME_BASE_STRAWCAKE,
                    Conventions = ObterPadroesDoBanco()
                };

                return store.Initialize();
            });

        public static DocumentConventions ObterPadroesDoBanco()
        {
            return new DocumentConventions
            {
                MaxNumberOfRequestsPerSession = 30,
                UseOptimisticConcurrency = true,
                SaveEnumsAsIntegers = true,
                IdentityPartsSeparator = '-'
            };
        }
    }
}
