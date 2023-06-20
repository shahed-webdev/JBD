namespace JBD.DATA.Models;

public class SettingProfitAmazon
{
    public int SettingProfitAmazonId { get; set; }
    public int UserRegistrationId { get; set; }
    public decimal Commission { get; set; }
    public decimal Expense { get; set; }
    public decimal ShippingUnitPrice { get; set; }
    public decimal MinimumShippingFee { get; set; }
    public UserRegistration UserRegistration { get; set; } = null!;
}