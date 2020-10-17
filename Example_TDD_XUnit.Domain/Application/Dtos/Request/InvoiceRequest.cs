using Example_TDD_XUnit.Domain.Enums;

namespace Example_TDD_XUnit.Domain.Application.Dtos.Request
{
    public class InvoiceRequest
    {
        /// <summary>
        /// Representa o numero da fatura
        /// </summary>
        /// <exemple>f17422bd-ed37-439b-a8d5-85cd3772ea31</exemple>
        public string Id { get; set; }

        public ClientRequest Client { get; set; }

        /// <summary>
        /// Representa o status da fatura 
        /// </summary>
        public EInvoiceStatus InvoiceStatus { get; set; }

        public InvoiceRequest(string id,
                              ClientRequest clientRequest,
                              EInvoiceStatus eInvoiceStatus)
        {
            Id = id;
            Client = clientRequest;
            InvoiceStatus = eInvoiceStatus;
        }





    }
}
