using CaseTechPB.Core.Entities;

namespace CaseTechPB.Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> InsertClientAsync(ClientEntitie client, CancellationToken ctx);
        Task<bool> UpdateClientAsync(ClientEntitie client, string email, CancellationToken ctx);
        Task<bool> DeleteClientAsync(string email, CancellationToken ctx);
        Task<IEnumerable<ClientEntitie>> GetAllClientAsync(CancellationToken ctx);
        Task<ClientEntitie> GetClient(string email, CancellationToken ctx);

    }
}
