using Example_TDD_XUnit.Domain.Application.Dtos.Request;
using Example_TDD_XUnit.Domain.Infrastructure.Interfacers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example_TDD_XUnit.Domain.Application.Services
{
    public class ClientService
    {
        private readonly IRepository _repository;

        public ClientService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ClientRequest>> GetClient()
        {
            return await _repository.GetClient().ConfigureAwait(false);
        }

        public async Task<IList<ClientRequest>> GetClientByPais(string pais)
        {
            var lstClientRequest =  await _repository.GetClient().ConfigureAwait(false);

            return lstClientRequest.Where(x => x.Pais == pais).ToList();

        }
    }
}
