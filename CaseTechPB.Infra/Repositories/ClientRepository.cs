using Dapper;
using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CaseTechPB.Infra.EntitiesDb;

namespace CaseTechPB.Infra.Repositories
{
    public class ClientRepository : BaseDbRepository<ClientEntitieDb>, IClientRepository
    {
        protected override IDbConnection _connection { get; set; }


        public ClientRepository(IConfiguration configuration) : base()
        {
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        private static readonly string GETALLCLIENTS = @"
            SELECT Email, FullName FROM dbo.Client
        ";

        private static readonly string GETCLIENT = @"
           SELECT Email, FullName FROM dbo.Client WHERE Email = @email
        ";

        private static readonly string INSERTCLIENT = @"
           INSERT INTO dbo.Client
            (
               Email,
               FullName
            )
            VALUES
            (
              @email,
              @name
            )
        ";

        private static readonly string UPDATECLIENT = @"
            UPDATE dbo.Client SET Email = @email, FullName = @name WHERE Email = @oddEmail
        ";

        private static readonly string DELETECLIENT = @"
            DELETE dbo.Client WHERE Email = @email
        ";

        public async Task<IEnumerable<ClientEntitie>> GetAllClients(CancellationToken ctx)
        {
            var result = await GetListAsync(GETALLCLIENTS, ctx, null);

            if (result is null)
            {
                return null;
            }

            return MapperFillListEntity(result);
            
        }

        public async Task<ClientEntitie> GetClientByEmail(string email, CancellationToken ctx)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", email, DbType.String);

            var result = await GetAsync(GETCLIENT, ctx, parameters);

            if (result is null)
            {
                return null;
            }

            return MapperFillEntity(result);

        }

        public async Task<int> InsertClient(ClientEntitie clientEntitie, CancellationToken ctx)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", clientEntitie.Email, DbType.String);
            parameters.Add("@name", clientEntitie.FullName, DbType.String);
           

            var result = await InsertAsync(INSERTCLIENT, ctx, parameters);

            return result;
        }

        public async Task<int> UpdateClient(ClientEntitie clientEntitie, string email, CancellationToken ctx)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", clientEntitie.Email, DbType.String);
            parameters.Add("@name", clientEntitie.FullName, DbType.String);
            parameters.Add("@oddEmail", email, DbType.String);
            
            var result = await UpdateAsync(UPDATECLIENT, ctx, parameters);

            return result;
        }

        public async Task<int> DeleteClient(string email, CancellationToken ctx)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", email, DbType.String);

            var result = await DeleteAsync(DELETECLIENT, ctx, parameters);

            return result;
        }

        private ClientEntitie MapperFillEntity(ClientEntitieDb clientEntitieDb)
        {
            
           return new ClientEntitie(clientEntitieDb.Email, clientEntitieDb.FullName)
           {
               Email = clientEntitieDb.Email,
               FullName = clientEntitieDb.FullName
           };
        }

        private IEnumerable<ClientEntitie> MapperFillListEntity(IEnumerable<ClientEntitieDb> clientEntitieDbList)
        {
            foreach(var clientEntitieDb in clientEntitieDbList)
            {
                yield return new ClientEntitie(clientEntitieDb.Email, clientEntitieDb.FullName)
                {
                    Email = clientEntitieDb.Email,
                    FullName = clientEntitieDb.FullName
                };
            }
        }
    }
}
