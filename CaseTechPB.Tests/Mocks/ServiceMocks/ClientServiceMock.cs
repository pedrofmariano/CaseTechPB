using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CaseTechPB.Tests.Mocks.ServiceMocks
{
    public class ClientServiceMock : MoqBase<IClientService, ClientServiceMock>
    {
        private static readonly CancellationToken ctx = new(false);

        public ClientServiceMock GetAllClients_Success()
        {
            mock.Setup(x => x.GetAllClientAsync(ctx)).ReturnsAsync(new List<ClientEntitie> { new ClientEntitie() });
            return this;
        }
        public ClientServiceMock GetAllClients_Null()
        {
            mock.Setup(x => x.GetAllClientAsync(ctx)).ReturnsAsync(() => null);
            return this;
        }
        public ClientServiceMock GetAllClients_Error()
        {
            mock.Setup(x => x.GetAllClientAsync(ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientServiceMock GetClients_Success()
        {
            mock.Setup(x => x.GetClient(It.IsAny<string>(), ctx)).ReturnsAsync(new ClientEntitie());
            return this;
        }
        public ClientServiceMock GetClients_Null()
        {
            mock.Setup(x => x.GetClient(It.IsAny<string>(), ctx)).ReturnsAsync(() => null);
            return this;
        }
        public ClientServiceMock GetClients_Error()
        {
            mock.Setup(x => x.GetClient(It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientServiceMock InsertClient_Success()
        {
            mock.Setup(x => x.InsertClientAsync(It.IsAny<ClientEntitie>(), ctx)).ReturnsAsync(true);
            return this;
        }
        public ClientServiceMock InsertClient_Fail()
        {
            mock.Setup(x => x.InsertClientAsync(It.IsAny<ClientEntitie>(), ctx)).ReturnsAsync(false);
            return this;
        }
        public ClientServiceMock InsertClient_Error()
        {
            mock.Setup(x => x.InsertClientAsync(It.IsAny<ClientEntitie>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientServiceMock UpdateClient_Success()
        {
            mock.Setup(x => x.UpdateClientAsync(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ReturnsAsync(true);
            return this;
        }
        public ClientServiceMock UpdateClient_Fail()
        {
            mock.Setup(x => x.UpdateClientAsync(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ReturnsAsync(false);
            return this;
        }
        public ClientServiceMock UpdateClient_Error()
        {
            mock.Setup(x => x.UpdateClientAsync(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientServiceMock DeleteClients_Success()
        {
            mock.Setup(x => x.DeleteClientAsync(It.IsAny<string>(), ctx)).ReturnsAsync(true);
            return this;
        }
        public ClientServiceMock DeleteClients_Fail()
        {
            mock.Setup(x => x.DeleteClientAsync(It.IsAny<string>(), ctx)).ReturnsAsync(false);
            return this;
        }
        public ClientServiceMock DeleteClients_Error()
        {
            mock.Setup(x => x.DeleteClientAsync(It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
    }
}
