using CaseTechPB.Api.Controllers;
using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using CaseTechPB.Tests.Mocks.ServiceMocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CaseTechPB.Tests.Controllers
{
    public class ClientControllerTest
    {
        private Mock<IClientService> _clientService;
        private static readonly CancellationToken ctx = new(false);

        [Fact]
        public async Task GetClient_Success()
        {
            _clientService = ClientServiceMock.Instance().GetClients_Success().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.Get(It.IsAny<string>(), ctx);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetClient_NotFound()
        {
            _clientService = ClientServiceMock.Instance().GetClients_Null().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.Get(It.IsAny<string>(), ctx);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetClient_Error()
        {
            _clientService = ClientServiceMock.Instance().GetClients_Error().Mock();
            var controller = new ClientController(_clientService.Object);
            await Assert.ThrowsAsync<Exception>(async () => await controller.Get(It.IsAny<string>(), ctx));
        }
        [Fact]
        public async Task GetAllClient_Success()
        {
            _clientService = ClientServiceMock.Instance().GetAllClients_Success().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.GetList(ctx);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetAllClient_NotFound()
        {
            _clientService = ClientServiceMock.Instance().GetAllClients_Null().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.GetList(ctx);
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public async Task GetAllClient_Error()
        {
            _clientService = ClientServiceMock.Instance().GetAllClients_Error().Mock();
            var controller = new ClientController(_clientService.Object);
            await Assert.ThrowsAsync<Exception>(async () => await controller.GetList(ctx));
        }
        [Fact]
        public async Task PostClient_Success()
        {
            _clientService = ClientServiceMock.Instance().InsertClient_Success().Mock();
            var controller = new ClientController(_clientService.Object);
            
            var clientEntitie = new ClientEntitie("teste@teste.com","teste teste");

            var result = await controller.Post(clientEntitie, ctx);
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task PostClient_Fail()
        {
            _clientService = ClientServiceMock.Instance().InsertClient_Fail().Mock();
            var controller = new ClientController(_clientService.Object);

            var clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await controller.Post(clientEntitie, ctx);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task PostClient_Error()
        {
            _clientService = ClientServiceMock.Instance().InsertClient_Error().Mock();
            var controller = new ClientController(_clientService.Object);

            var clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            await Assert.ThrowsAsync<Exception>(async () => await controller.Post(clientEntitie, ctx));
        }
        [Fact]
        public async Task UpdateClient_Success()
        {
            _clientService = ClientServiceMock.Instance().UpdateClient_Success().Mock();
            var controller = new ClientController(_clientService.Object);

            var clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await controller.Put(clientEntitie, It.IsAny<string>(), ctx);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task UpdateClient_Fail()
        {
            _clientService = ClientServiceMock.Instance().UpdateClient_Fail().Mock();
            var controller = new ClientController(_clientService.Object);

            var clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");

            var result = await controller.Put(clientEntitie, It.IsAny<string>(), ctx);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task UpdateClient_Error()
        {
            _clientService = ClientServiceMock.Instance().UpdateClient_Error().Mock();
            var controller = new ClientController(_clientService.Object);

            var clientEntitie = new ClientEntitie("teste@teste.com", "teste teste");
            await Assert.ThrowsAsync<Exception>(async () => await controller.Put(clientEntitie, It.IsAny<string>(), ctx));
        }
        [Fact]
        public async Task DeleteClient_Success()
        {
            _clientService = ClientServiceMock.Instance().DeleteClients_Success().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.Delete(It.IsAny<string>(), ctx);
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task DeleteClient_Fail()
        {
            _clientService = ClientServiceMock.Instance().DeleteClients_Fail().Mock();
            var controller = new ClientController(_clientService.Object);
            var result = await controller.Delete(It.IsAny<string>(), ctx);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task DeleteClient_Error()
        {
            _clientService = ClientServiceMock.Instance().DeleteClients_Error().Mock();
            var controller = new ClientController(_clientService.Object);
            await Assert.ThrowsAsync<Exception>(async () => await controller.Delete(It.IsAny<string>(), ctx));
        }
    }
}
