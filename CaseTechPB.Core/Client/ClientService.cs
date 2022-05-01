using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CaseTechPB.Core.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientEntitie>> GetAllClientAsync(CancellationToken ctx)
        {
            var result = await _clientRepository.GetAllClients(ctx);

            return result;
        }

        public async Task<ClientEntitie> GetClient(string email, CancellationToken ctx)
        {
            var result = await _clientRepository.GetClientByEmail(email, ctx);

            return result;
        }

        public async Task<bool> InsertClientAsync(ClientEntitie client, CancellationToken ctx)
        {
            try
            {

                if (IsValidEmail(client.Email))
                {
                    if (IsValid(client))
                    {
                        return await _clientRepository.InsertClient(client, ctx) > 0;
                        
                    }
                }
                return false;

            } 
            catch (Exception ex)
            {
                throw new Exception("Registration data is invalid");
            }
        }

        public async Task<bool> UpdateClientAsync(ClientEntitie client,  string email, CancellationToken ctx)
        {
            try
            {

                if (IsValidEmail(client.Email))
                {
                    if (IsValid(client))
                    {
                        return await _clientRepository.UpdateClient(client, email, ctx) > 0;

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Registration data is invalid");
            }
        }

        public async Task<bool> DeleteClientAsync(string email, CancellationToken ctx)
        {

            var result = await _clientRepository.DeleteClient(email, ctx) > 0;

            return result;
        }


        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private static bool IsValid(ClientEntitie clientEntitie)
        {
            if(string.IsNullOrEmpty(clientEntitie.FullName))
                return false;
            return true;
        }
    }
}
