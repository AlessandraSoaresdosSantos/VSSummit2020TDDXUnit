using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using Example_TDD_XUnit.Domain.Infrastructure.Interfacers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example_TDD_XUnit.Domain.Infrastructure
{
    public class Repository : IRepository
    {
        public Repository() { }

        public async Task<IList<InvoiceRequest>> GetInvoice()
        {
            return await GenerateListInvoiceRequest().ConfigureAwait(false);
        }

        public IList<InvoiceRequest> GetInvoice(Enums.EInvoiceStatus eInvoiceStatus)
        {
            return GenerateListInvoiceRequest()
                    .Result.Where(x => x.InvoiceStatus.Equals(eInvoiceStatus)).ToList();
        }

        public async Task<IList<ClientRequest>> GetClient()
        {
            return await GenerateClientRequest().ConfigureAwait(false);
        }

        private async Task<IList<InvoiceRequest>> GenerateListInvoiceRequest()
        {
            return await Task.FromResult(new List<InvoiceRequest>
            {
                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.New),

                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.New),

                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.Canceled),

                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.Completed),

                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.Finish),

                new InvoiceRequest(GenerateNewGuid(),
                                   GenerateClientRequest().Result.OrderBy(x => Guid.NewGuid()).FirstOrDefault(),
                                   Enums.EInvoiceStatus.Paid)
            });
        }

        private async Task<IList<ClientRequest>> GenerateClientRequest()
        {
            return await Task.FromResult(new List<ClientRequest>
            {
              new ClientRequest{ Id= GenerateNewGuid(),
                                 Nome = "José Luis Santos",
                                 EnderecoCompleto = "Rua Flor, 40 - casa 2A - Parque Sevilha - Vila Ré",
                                 Cidade = "São Paulo",
                                 Cep = "04258-320",
                                 UF = "SP",
                                 Pais = "Brasil"},

              new ClientRequest{ Id= GenerateNewGuid(),
                                 Nome = "Assoalhos Barbosa e Lima Ltda.-ME",
                                 EnderecoCompleto = "Avenida XV de Outubro, 4300 - Centro",
                                 Cidade = "São Paulo",
                                 Cep = "02012-840",
                                 UF = "SP",
                                 Pais = "Brasil"},


              new ClientRequest{ Id= GenerateNewGuid(),
                                 Nome = "Papelaria Lápis Azul Ltda.",
                                 EnderecoCompleto = "Avenida Paulista, 903 - Paulista",
                                 Cidade = "São Paulo",
                                 Cep = "08020-000",
                                 UF = "SP",
                                 Pais = "Brasil"},

              new ClientRequest{ Id= GenerateNewGuid(),
                                 Nome = "Luis Calmon",
                                 EnderecoCompleto = "Avenida Luz, 340 - Centro",
                                 Cidade = "São Paulo",
                                 Cep = "01025-000",
                                 UF = "SP",
                                 Pais = "Brasil"}
            });
        }

        private static string GenerateNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
