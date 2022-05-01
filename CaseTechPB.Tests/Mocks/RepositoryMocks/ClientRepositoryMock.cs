using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CaseTechPB.Tests.Mocks.RepositoryMocks
{
    public class ClientRepositoryMock : MoqBase<IClientRepository, ClientRepositoryMock>
    {
        private static readonly CancellationToken ctx = new(false);
        public ClientRepositoryMock InsertClient_Success()
        {
            mock.Setup(x => x.InsertClient(It.IsAny<ClientEntitie>(), ctx)).ReturnsAsync(1);
            return this;
        }
        public ClientRepositoryMock InsertClient_Fail()
        {
            mock.Setup(x => x.InsertClient(It.IsAny<ClientEntitie>(), ctx)).ReturnsAsync(0);
            return this;
        }
        public ClientRepositoryMock InsertClient_Error()
        {
            mock.Setup(x => x.InsertClient(It.IsAny<ClientEntitie>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientRepositoryMock GetClient_Success()
        {
            mock.Setup(x => x.GetClientByEmail(It.IsAny<string>(), ctx)).ReturnsAsync(new ClientEntitie());
            return this;
        }
        public ClientRepositoryMock GetClient_Error()
        {
            mock.Setup(x => x.GetClientByEmail(It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }

        public ClientRepositoryMock GetAllClient_Success()
        {
            mock.Setup(x => x.GetAllClients(ctx)).ReturnsAsync(new List<ClientEntitie> { new ClientEntitie() });
            return this;
        }
        public ClientRepositoryMock GetAllClient_Error()
        {
            mock.Setup(x => x.GetAllClients(ctx)).ThrowsAsync(new Exception());
            return this;
        }

        public ClientRepositoryMock UpdateClient_Success()
        {
            mock.Setup(x => x.UpdateClient(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ReturnsAsync(1);
            return this;
        }
        public ClientRepositoryMock UpdateClient_Fail()
        {
            mock.Setup(x => x.UpdateClient(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ReturnsAsync(0);
            return this;
        }
        public ClientRepositoryMock UpdateClient_Error()
        {
            mock.Setup(x => x.UpdateClient(It.IsAny<ClientEntitie>(), It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }
        public ClientRepositoryMock DeleteClient_Success()
        {
            mock.Setup(x => x.DeleteClient(It.IsAny<string>(), ctx)).ReturnsAsync(1);
            return this;
        }
        public ClientRepositoryMock DeleteClient_Fail()
        {
            mock.Setup(x => x.DeleteClient(It.IsAny<string>(), ctx)).ReturnsAsync(0);
            return this;
        }
        public ClientRepositoryMock DeleteClient_Error()
        {
            mock.Setup(x => x.DeleteClient(It.IsAny<string>(), ctx)).ThrowsAsync(new Exception());
            return this;
        }

    }
}
