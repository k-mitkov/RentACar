using Microsoft.AspNetCore.Identity;

namespace DataBase.Models
{
    public class User : IdentityUser
    {
        #region Properties

        public Client Client;

        #endregion
    }
}
