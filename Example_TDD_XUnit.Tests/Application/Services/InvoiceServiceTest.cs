using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using Example_TDD_XUnit.Domain.Application.Services;
using Example_TDD_XUnit.Domain.Enums;
using Example_TDD_XUnit.Domain.Infrastructure.Interfacers;
using FakeItEasy;
using FizzWare.NBuilder;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace Example_TDD_XUnit.Tests.Application.Services
{
    public class InvoiceServiceTest : TestBase
    {
        #region DI Properties
        private readonly IRepository _repository;
        private readonly InvoiceService _invoiceService;
        #endregion

        #region DTO Properties
        private readonly InvoiceRequest _invoiceRequest;
        private readonly ClientRequest _clientRequest;
        #endregion

        public InvoiceServiceTest()
        {
            _repository = A.Fake<IRepository>();

            _invoiceService = new InvoiceService(_repository);

            #region Mock DTOs properties
            _clientRequest = Builder<ClientRequest>.CreateNew().Build();
            _invoiceRequest = new InvoiceRequest(GenerateNewGuid(), _clientRequest, Domain.Enums.EInvoiceStatus.New);

            #endregion
        }

        [Fact]
        [Trait("InvoiceService", "GetInvoice")]
        public async Task GetInvoice_WhenGetListInvoiceRequestIsSuccessful_ShouldReturnInvoiceList()
        {
            //arrange
            IList<InvoiceRequest> invoiceRequests = GenerateListInvoiceRequest(_invoiceRequest, 4);

            A.CallTo(() => _repository.GetInvoice()).Returns(invoiceRequests);

            //act
            var lstInvoice = await _invoiceService.GetInvoice().ConfigureAwait(false);

            //assert
            lstInvoice.Should().NotBeNullOrEmpty(because: "Need return List with elements");
            lstInvoice.Should().HaveCountGreaterOrEqualTo(1, because: "List need return one or more element(s)");
            lstInvoice.Should().NotContainNulls(because: "Need return List with elements");
        }

        [Fact]
        [Trait("InvoiceService", "GetInvoice")]
        public async Task GetInvoice_WhenGetListInvoiceRequestNotSuccessful_ShouldReturnEmptyInvoiceList()
        {
            //arrange
            A.CallTo(() => _repository.GetInvoice()).Returns(new List<InvoiceRequest>());

            //act
            var lstInvoice = await _invoiceService.GetInvoice().ConfigureAwait(false);

            //assert
            lstInvoice.Should().BeEmpty(because: "Test with return Empty result");
            lstInvoice.Should().BeEquivalentTo(new List<InvoiceRequest>());
            lstInvoice.Should().NotContainNulls(because: "Need return Empty List");
            lstInvoice.Should().HaveCount(0);
        }


        [Fact]
        [Trait("InvoiceService", "GetInvoice")]
        public void GetInvoice_WhenGetListInvoiceRequestWithEInvoiceStatusParameterIsSuccessful_ShouldReturnInvoiceList()
        {
            //arrange
            IList<InvoiceRequest> invoiceRequests = GenerateListInvoiceRequest(_invoiceRequest, 4);
            A.CallTo(() => _repository.GetInvoice(A<EInvoiceStatus>.Ignored)).Returns(invoiceRequests);

            //act
            var lstInvoice = _invoiceService.GetInvoice(EInvoiceStatus.New);

            //assert
            lstInvoice.Should().NotBeNullOrEmpty(because: "Need return List with elements");
            lstInvoice.Should().HaveCountGreaterOrEqualTo(1, because: "List need return one or more element(s)");
            lstInvoice.Should().NotContainNulls(because: "Need return List with elements");
        }


        [Fact]
        [Trait("InvoiceService", "GetInvoice")]
        public void GetInvoice_WhenGetListInvoiceRequestWithEInvoiceStatusParameterNotSuccessful_ShouldReturnEmptyInvoiceList()
        {
            //arrange
            A.CallTo(() => _repository.GetInvoice(A<EInvoiceStatus>.Ignored)).Returns(new List<InvoiceRequest>());

            //act
            var lstInvoice = _invoiceService.GetInvoice(EInvoiceStatus.New);

            //assert
            lstInvoice.Should().BeEmpty(because: "Test with return Empty result");
            lstInvoice.Should().BeEquivalentTo(new List<InvoiceRequest>());
            lstInvoice.Should().NotContainNulls(because: "Need return Empty List");
            lstInvoice.Should().HaveCount(0);
        }

        [Fact]
        [Trait("InvoiceService", "GetInvoice")]
        public void GetInvoice_WhenGetNullInvoiceRequestWithEInvoiceStatusParameterNotSuccessful_ShouldReturnEmptyInvoiceList()
        {
            //arrange
            A.CallTo(() => _repository.GetInvoice(A<EInvoiceStatus>.Ignored)).Returns(null);

            //act
            var lstInvoice = _invoiceService.GetInvoice(EInvoiceStatus.New);

            //assert
            lstInvoice.Should().BeEmpty(because: "Test with return Empty result");
            lstInvoice.Should().BeEquivalentTo(new List<InvoiceRequest>());
            lstInvoice.Should().NotContainNulls(because: "Need return Empty List");
            lstInvoice.Should().HaveCount(0);
        }
    }
}

