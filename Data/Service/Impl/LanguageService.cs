using Data.Models;
using DesktopClient.Util;
using System;
using System.Collections.Generic;

namespace Data.Service.Impl
{
    public class LanguageService : ILanguageService
    {
        #region Declaration
        private IDataService data;
        #endregion

        #region Constructor
        public LanguageService()
        {
            data = new DataService();
        }
        #endregion

        #region Methods
        public IEnumerable<Language> GetLanguages()
        {
            try
            {
                return data.GetLanguages();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }
        #endregion
    }
}
