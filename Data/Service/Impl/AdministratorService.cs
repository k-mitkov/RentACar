using Data.Models;
using DesktopClient.Util;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Data.Service.Impl
{
    public class AdministratorService : IAdministratorService
    {
        #region Declaration

        private IDataService data;

        #endregion

        #region Constructor
        public AdministratorService()
        {
            data = new DataService();
        }

        #endregion

        #region Methods

        public bool AddNewAdmin(Admin admin)
        {
            try
            {
                data.AddNewAdmin(admin);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return false ;
            }
        }

        public Admin Login(string username, string password)
        {
            try
            {
                password = EncryptPassword(password);
                return data.FindAdminByUsernameAndPassword(username, password);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        private string EncryptPassword(string password)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(password);
                data = new SHA256Managed().ComputeHash(data);
                return Encoding.ASCII.GetString(data);
            }
            catch (Exception e)
            {
                ExceptionLogger.LoggException(e);
                return null;
            }
        }
        #endregion
    }
}
