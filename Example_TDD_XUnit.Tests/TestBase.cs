using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using System;
using System.Collections.Generic;

namespace Example_TDD_XUnit.Tests
{
    public class TestBase
    {

        public static string GenerateNewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public IList<InvoiceRequest> GenerateListInvoiceRequest(InvoiceRequest  invoiceRequest, int number)
        {

            IList<InvoiceRequest> lstInvoice = new List<InvoiceRequest>();

            for (int i = 0; i < number; i++)
            {
                lstInvoice.Add(invoiceRequest);
            }

            return lstInvoice;
        }
    }
}
