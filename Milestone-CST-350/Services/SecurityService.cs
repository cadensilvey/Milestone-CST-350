using Milestone_CST_350.Models;
using System.Security.Cryptography.Xml;

namespace Milestone_CST_350.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();
        RegisterDAO registerDAO = new RegisterDAO();

        public bool isValid(RegistrationModel user)
        {
            return securityDAO.FindUserByNameAndPassword(user);
        }

        public bool addUser(RegistrationModel user)
        {
            return registerDAO.AddUserToDatabase(user);
        }
    }
}
