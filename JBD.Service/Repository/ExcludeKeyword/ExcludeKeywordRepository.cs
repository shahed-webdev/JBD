using AutoMapper;
using AutoMapper.QueryableExtensions;
using JBD.DATA;
using JBD.DATA.Enums;
using JBD.DATA.Models;
using JBD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace JBD.Service.Repository;

public class ExcludeKeywordRepository:BaseRepository<ExcludeKeyword>, IExcludeKeywordRepository
{
    private readonly IMapper _mapper;
    public ExcludeKeywordRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public Task<List<ExcludeKeywordVM>> GetAllAsync(int userRegistrationId)
    {
        return Context.ExcludeKeywords.Where(e => e.UserRegistrationId == userRegistrationId).ProjectTo<ExcludeKeywordVM>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public Task<List<string>> GetAllByTypeAsync(int userRegistrationId, ExcludeKeywordType type)
    {
        return Context.ExcludeKeywords.Where(e => e.UserRegistrationId == userRegistrationId && e.KeywordType == type).Select( e=> e.Keyword)
            .ToListAsync();
    }

    public async Task AddKeywordsAsync(int userRegistrationId, ExcludeKeywordType type, List<string> keywords)
    {
        var excludeKeyword = keywords.Where(k=> !string.IsNullOrEmpty(k)).Select(e => new ExcludeKeyword
        {
            UserRegistrationId = userRegistrationId,
            KeywordType = type,
            Keyword = e.Trim(),
        }).ToList();

        Context.AddRange(excludeKeyword);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteKeywordsAsync(int userRegistrationId, ExcludeKeywordType type)
    {
        var keywords =  await  Context.ExcludeKeywords.Where(e => e.UserRegistrationId == userRegistrationId && e.KeywordType == type)
            .ToListAsync();
        Context.RemoveRange(keywords);

        await Context.SaveChangesAsync();
    }
}