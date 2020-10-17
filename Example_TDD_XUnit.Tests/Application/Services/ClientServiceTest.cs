using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using Example_TDD_XUnit.Domain.Application.Services;
using Example_TDD_XUnit.Domain.Infrastructure.Interfacers;
using FakeItEasy;
using FizzWare.NBuilder;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Example_TDD_XUnit.Tests.Application.Services
{
    public class ClientServiceTest
    {
        #region DI Properties
        private readonly IRepository _repository;
        private readonly ClientService _clientService;

        #endregion

        public ClientServiceTest()
        {
            _repository = A.Fake<IRepository>();

            _clientService = new ClientService(_repository);
        }

        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClient_WhenGetListClientRequestIsSuccessful_ShouldReturnClientList()
        {
            //arrange
            IList<ClientRequest> clientRequest = Builder<ClientRequest>.CreateListOfSize(4).Build();
            A.CallTo(() => _repository.GetClient()).Returns(clientRequest);

            //act
            var lstClient = await _clientService.GetClient().ConfigureAwait(false);

            //assert
            lstClient.Should().NotBeEmpty(because: "Need return List with elements");
            lstClient.Should().NotBeNull();
            lstClient.Should().HaveCountGreaterOrEqualTo(1, because: "List need return one or more element(s)");
            lstClient.Should().NotContainNulls(because: "Need return List with elements");
        }

        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClient_WhenGetListClientRequestNotSuccessful_ShouldReturnEmptyClientList()
        {
            //arrange
            A.CallTo(() => _repository.GetClient()).Returns(new List<ClientRequest>());

            //act
            var lstClient = await _clientService.GetClient().ConfigureAwait(false);

            //assert
            lstClient.Should().BeEmpty(because: "Test with return Empty result");
            lstClient.Should().BeEquivalentTo(new List<ClientRequest>());
            lstClient.Should().NotContainNulls(because: "Need return Empty List");
            lstClient.Should().HaveCount(0);
        }

        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClient_WhenGetEmptyClientRequestNotSuccessful_ShouldReturnEmptyClientList()
        {
            //arrange
            A.CallTo(() => _repository.GetClient());

            //act
            var lstClient = await _clientService.GetClient().ConfigureAwait(false);

            //assert
            lstClient.Should().BeEmpty().And.HaveCount(0);
            lstClient.Should().NotContainNulls(because: "Need return Empty List");
            lstClient.Should().HaveCount(0);
        }




        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClientByPais_WhenGetListClientRequestWithPaisParameterIsSuccessful_ShouldReturnClientList()
        {
            //arrange
            IList<ClientRequest> clientRequest = Builder<ClientRequest>.CreateListOfSize(4).Build();
            A.CallTo(() => _repository.GetClient()).Returns(clientRequest);

            //act
            var lstClient = await _clientService.GetClientByPais("Argentina").ConfigureAwait(false);

            //assert
            lstClient.Should().NotBeEmpty(because: "Need return List with elements");
            lstClient.Should().NotBeNull();
            lstClient.Should().HaveCountGreaterOrEqualTo(1, because: "List need return one or more element(s)");
            lstClient.Should().NotContainNulls(because: "Need return List with elements");
        }

        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClientByPais_WhenGetEmptyListClientRequestWithPaisParameterNotSuccessful_ShouldReturnEmptyClientList()
        {
            //arrange
            A.CallTo(() => _repository.GetClient()).Returns(new List<ClientRequest>());

            //act
            var lstClient = await _clientService.GetClientByPais("Brasil").ConfigureAwait(false);

            //assert
            lstClient.Should().BeEmpty(because: "Test with return Empty result");
            lstClient.Should().BeEquivalentTo(new List<ClientRequest>());
            lstClient.Should().NotContainNulls(because: "Need return Empty List");
            lstClient.Should().HaveCount(0);
        }

        [Fact]
        [Trait("ClientService", "GetClient")]
        public async Task GetClientByPais_WhenGetEmptyListClientRequestWithPaisParameterNullNotSuccessful_ShouldReturnEmptyClientList()
        {
            //arrange
            A.CallTo(() => _repository.GetClient());

            //act
            var lstClient = await _clientService.GetClientByPais(null).ConfigureAwait(false);

            //assert
            lstClient.Should().BeEmpty().And.HaveCount(0);
            lstClient.Should().NotContainNulls(because: "Need return Empty List");
            lstClient.Should().HaveCount(0);
        }







    }
}
