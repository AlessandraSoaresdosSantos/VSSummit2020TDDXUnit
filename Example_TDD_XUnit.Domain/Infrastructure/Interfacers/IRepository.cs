using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example_TDD_XUnit.Domain.Infrastructure.Interfacers
{
    public interface IRepository
    {

        Task<IList<InvoiceRequest>> GetInvoice();
        IList<InvoiceRequest> GetInvoice(Enums.EInvoiceStatus eInvoiceStatus);
        Task<IList<ClientRequest>> GetClient();
    }
}
