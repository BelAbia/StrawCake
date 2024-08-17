using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Operations.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StrawCake.Dominio.RavenDB
{
    public static class DocumentStoreHolder
    {
        static X509Certificate2 clientCertificate = new X509Certificate2("C:\\Users\\Usuario\\Documents\\CertRaven-PESSOAL\\free.isacastro.client.certificate.pfx");

        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                var store = new DocumentStore
                {
                    Certificate = clientCertificate,
                    //Urls = new[] { "http://127.0.0.1:8080/" },
                    Urls = new[] { "https://a.free.isacastro.ravendb.cloud/" },
                    Database = "StrawCake",
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
