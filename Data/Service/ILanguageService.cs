using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
    }
}
