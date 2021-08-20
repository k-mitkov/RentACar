using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            return data.GetLanguages();
        }
        #endregion
    }
}
