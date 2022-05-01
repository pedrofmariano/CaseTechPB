namespace CaseTechPB.Core.Entities
{
    public class ClientEntitie
    {
        public string Email { get; set; }
        public string FullName { get; set; }

        public ClientEntitie() { }
        public ClientEntitie(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
        }
    }
}
