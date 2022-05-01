using CaseTechPB.Core.Client;
using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using CaseTechPB.Tests.Mocks.RepositoryMocks;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseTechPB.Tests.Services
{
    public class ClientServiceTest
    {
        private Mock<IClientRepository> _clientRepository;
        private static readonly CancellationToken ctx = new(false);

        [Fact]
        public async Task GetClients_Success()
        {
            _clientRepository = ClientRepositoryMock.Instance().GetAllClient_Success().Mock();
            var service = new ClientService(_clientRepository.Object);
            var result = await service.GetAllClientAsync(ctx);
            Assert.True(result.Any());
        }

        [Fact]
        public async Task GetClients_Error()
        {
            _clientRepository = ClientRepositoryMock.Instance().GetAllClient_Error().Mock();
            var service = new ClientService(_clientRepository.Object);
            await Assert.ThrowsAsync<Exception>(async () => await service.GetAllClientAsync(ctx));
        }
        [Fact]
        public async Task GetClient_Success()
        {
            _clientRepository = ClientRepositoryMock.Instance().GetClient_Success().Mock();
            var service = new ClientService(_clientRepository.Object);
            var result = await service.GetClient(It.IsAny<string>(), ctx);
            Assert.IsType<ClientEntitie>(result);
        }
        [Fact]
        public async Task GetClient_Error()
        {
            _clientRepository = ClientRepositoryMock.Instance().GetClient_Error().Mock();
            var service = new ClientService(_clientRepository.Object);
            await Assert.ThrowsAsync<Exception>(async () => await service.GetClient(It.IsAny<string>(), ctx));
        }
        [Fact]
        public async Task InsertClient_Success()
        {
            _clientRepository = ClientRepositoryMock.Instance().InsertClient_Success().Mock();
            var service = new ClientService(_clientRepository.Object);

            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await service.InsertClientAsync(clientEntitie, ctx);

            Assert.True(result);
        }
        [Fact]
        public async Task InsertClient_Fail()
        {
            _clientRepository = ClientRepositoryMock.Instance().InsertClient_Fail().Mock();
            var service = new ClientService(_clientRepository.Object);

            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await service.InsertClientAsync(clientEntitie, ctx);

            Assert.False(result);
        }
        [Fact]
        public async Task InsertClient_Error()
        {
            _clientRepository = ClientRepositoryMock.Instance().InsertClient_Error().Mock();
            var service = new ClientService(_clientRepository.Object);

            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            await Assert.ThrowsAsync<Exception>(async () => await service.InsertClientAsync(clientEntitie, ctx));
        }
        [Fact]
        public async Task UpdateClient_Success()
        {
            _clientRepository = ClientRepositoryMock.Instance().UpdateClient_Success().Mock();
            var service = new ClientService(_clientRepository.Object);

            string email = "teste@teste1.com";
            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await service.UpdateClientAsync(clientEntitie, email, ctx);

            Assert.True(result);
        }
        [Fact]
        public async Task UpdateClient_Fail()
        {
            _clientRepository = ClientRepositoryMock.Instance().UpdateClient_Fail().Mock();
            var service = new ClientService(_clientRepository.Object);
            
            string email = "teste@teste1.com";
            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await service.UpdateClientAsync(clientEntitie, email, ctx);

            Assert.False(result);
        }
        [Fact]
        public async Task UpdateClient_Error()
        {
            _clientRepository = ClientRepositoryMock.Instance().UpdateClient_Error().Mock();
            var service = new ClientService(_clientRepository.Object);

            string email = "teste@teste1.com";
            ClientEntitie clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            await Assert.ThrowsAsync<Exception>(async () => await service.UpdateClientAsync(clientEntitie, email, ctx));
        }
        [Fact]
        public async Task DeleteClient_Success()
        {
            _clientRepository = ClientRepositoryMock.Instance().DeleteClient_Success().Mock();
            var service = new ClientService(_clientRepository.Object);
            var result = await service.DeleteClientAsync(It.IsAny<string>(), ctx);

            Assert.True(result);
        }
        [Fact]
        public async Task DeleteClient_Fail()
        {
            _clientRepository = ClientRepositoryMock.Instance().DeleteClient_Fail().Mock();
            var service = new ClientService(_clientRepository.Object);
            var result = await service.DeleteClientAsync(It.IsAny<string>(), ctx);

            Assert.False(result);
        }
        [Fact]
        public async Task DeleteClient_Error()
        {
            _clientRepository = ClientRepositoryMock.Instance().DeleteClient_Error().Mock();
            var service = new ClientService(_clientRepository.Object);
            await Assert.ThrowsAsync<Exception>(async () => await service.DeleteClientAsync(It.IsAny<string>(), ctx));
        }

    }
}
