using CaseTechPB.Core.Entities;

namespace CaseTechPB.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<int> InsertClient(ClientEntitie clientEntitie, CancellationToken ctx);
        Task<IEnumerable<ClientEntitie>> GetAllClients(CancellationToken ctx);
        Task<ClientEntitie> GetClientByEmail(string email, CancellationToken ctx);
        Task<int> UpdateClient(ClientEntitie client, string email, CancellationToken ctx);
        Task<int> DeleteClient(string email, CancellationToken ctx);
    }
}
