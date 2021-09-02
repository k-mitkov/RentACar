using Data.Models;
using System.Collections.Generic;

namespace Data.Service
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
    }
}
