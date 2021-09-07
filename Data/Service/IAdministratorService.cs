using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface IAdministratorService
    {
        bool AddNewAdmin(Admin admin);
        Admin Login(string username, string password);
    }
}
