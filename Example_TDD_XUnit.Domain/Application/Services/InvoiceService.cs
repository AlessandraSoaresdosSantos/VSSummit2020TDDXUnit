using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using Example_TDD_XUnit.Domain.Infrastructure.Interfacers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example_TDD_XUnit.Domain.Application.Services
{
    public class InvoiceService
    {
        private readonly IRepository _repository;

        public InvoiceService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<InvoiceRequest>> GetInvoice()
        {
            return await _repository.GetInvoice().ConfigureAwait(false);
        }

        public IList<InvoiceRequest> GetInvoice(Enums.EInvoiceStatus eInvoiceStatus)
        {
            var lstInvoice = _repository.GetInvoice(eInvoiceStatus);

            if (!ExistClientRequest(lstInvoice))
                return new List<InvoiceRequest>();

            return lstInvoice;
        }

        private bool ExistClientRequest(IList<InvoiceRequest> invoiceRequest)
        {
            return invoiceRequest.Select(_ => _.Client).Count() > 0;
        }
    }
}
