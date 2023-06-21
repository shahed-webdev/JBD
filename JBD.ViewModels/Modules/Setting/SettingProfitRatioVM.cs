namespace JBD.ViewModel;

public class SettingProfitRatioVM
{
    public int SettingProfitRatioId { get; set; }
    public decimal AmazonSellingPrice { get; set; }
    public decimal PercentageWithPriceAndProfit { get; set; }
    public decimal PlusAmount { get; set; }
    public decimal MinusAmount { get; set; }
    public decimal ProfitAmount { get; set; }
}