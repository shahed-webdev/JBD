namespace JBD.DATA.Models;

public class SettingProfitRatio
{
    public int SettingProfitRatioId { get; set; }
    public int UserRegistrationId { get; set; }
    public decimal AmazonSellingPrice { get; set; }
    public decimal PercentageWithPriceAndProfit { get; set; }
    public decimal PlusAmount { get; set; }
    public decimal MinusAmount { get; set; }
    public decimal ProfitAmount { get; set; }
    public UserRegistration UserRegistration { get; set; } = null!;
}