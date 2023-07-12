using JBD.DATA.Enums;

namespace JBD.ViewModel;

public class ExcludeKeywordVM
{
    public ExcludeKeywordType KeywordType { get; set; }
    public string Keyword { get; set; } = null!;
}