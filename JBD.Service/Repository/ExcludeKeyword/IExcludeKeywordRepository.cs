using JBD.DATA.Enums;
using JBD.DATA.Models;
using JBD.ViewModel;

namespace JBD.Service.Repository;

public interface IExcludeKeywordRepository: IBaseRepository<ExcludeKeyword>
{
    Task<List<string>> GetAllByTypeAsync(int userRegistrationId, ExcludeKeywordType type);
    Task AddKeywordsAsync(int userRegistrationId, ExcludeKeywordType type, List<string> keywords);
    Task DeleteKeywordsAsync(int userRegistrationId, ExcludeKeywordType type);
}