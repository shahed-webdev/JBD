using JBD.DATA.Enums;

namespace JBD.DATA.Models;

public class ExcludeKeyword
{
    public int ExcludeKeywordId { get; set; }
    public int UserRegistrationId { get; set; }
    public ExcludeKeywordType KeywordType { get; set; }
    public string Keyword  {get; set; } = null!;
    public UserRegistration UserRegistration { get; set; } = null!;
}