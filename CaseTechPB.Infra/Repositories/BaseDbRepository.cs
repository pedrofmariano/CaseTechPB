using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CaseTechPB.Infra.Repositories
{
    public abstract class BaseDbRepository<T>
    {
        protected abstract IDbConnection _connection { get; set; }

      
        public async Task<IEnumerable<T>> GetListAsync(string query, CancellationToken ctx, DynamicParameters parameters)
        {
            try
            {
                _connection.Open();
                return parameters is null ? await _connection.QueryAsync<T>(query, ctx) : await _connection.QueryAsync<T>(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public async Task<T> GetAsync(string query, CancellationToken ctx, DynamicParameters parameters)
        {
            try
            {
                _connection.Open();
                return parameters is null ? await _connection.QueryFirstOrDefaultAsync<T>(query, ctx) : await _connection.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public async Task<int> InsertAsync(string query, CancellationToken ctx, DynamicParameters parameters)
        {
            try
            {
                _connection.Open();
                return parameters is null ? await _connection.ExecuteAsync(query, ctx) : await _connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("PRIMARY KEY constraint"))
                {
                    return 0;
                }
                throw new Exception(ex.StackTrace);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public async Task<int> UpdateAsync(string query, CancellationToken ctx, DynamicParameters parameters)
        {
            try
            {
                _connection.Open();
                return parameters is null ? await _connection.ExecuteAsync(query, ctx) : await _connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public async Task<int> DeleteAsync(string query, CancellationToken ctx, DynamicParameters parameters)
        {
            try
            {
                _connection.Open();
                return parameters is null ? await _connection.ExecuteAsync(query, ctx) : await _connection.ExecuteAsync(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

    }
}