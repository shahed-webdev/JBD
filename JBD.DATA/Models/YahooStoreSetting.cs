namespace JBD.DATA.Models;

public class YahooStoreSetting
{
    public int YahooStoreSettingId { get; set; }
    public int UserRegistrationId { get; set; }
    public string StoreId { get; set; }
    public string Email { get; set; }
    public string StoreName { get; set; }


    //Email setting for store
    public string ApprovalEmailTemplate { get; set; }
    public string ShippingEmailTemplate { get; set; }
    public string CancellationEmailTemplate { get; set; }
    public string EmailSignature { get; set; }


    //Yahoo API linkage settings
    public string ClientID { get; set; }
    public string Secret { get; set; }
    public string Publickey { get; set; }
    public string Version { get; set; }

    public UserRegistration UserRegistration { get; set; } = null!;
}