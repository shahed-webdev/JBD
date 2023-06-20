using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JBD.DATA.Models;

public class SettingShippingFeeRatio
{
    public int SettingShippingFeeRatioId { get; set; }
    public int UserRegistrationId { get; set; }
    public decimal Size { get; set; } // Total of 3 sides - CM
    public decimal Weight { get; set; }
    public decimal Amount { get; set; }
    public UserRegistration UserRegistration { get; set; } = null!;
}
