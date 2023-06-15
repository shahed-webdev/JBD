namespace JBD.ViewModel;

public class ProductVM
{
    public int ProductId { get; set; }

    //Product info
    public string Asin { get; set; }
    public string ProductCode { get; set; }
    public string? Brand { get; set; }
    public string ProductName { get; set; }
    public string? ProductDescription { get; set; }

    //Category/Size/Weight
    public int CategoryId { get; set; }
    public string? Category { get; set; }
    public string? Rank { get; set; }
    public decimal Size { get; set; }
    public decimal Weight { get; set; }

    //Pricing info
    public decimal PurchasePrice { get; set; }
    public decimal SalesPrice { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal GrossProfit { get; set; }

    //Amazon info
    public int NumberOfTimeSold { get; set; }
    public string? AmazonJpLink { get; set; }
    public string? OtherPurchasingSiteLink { get; set; }
    public string? YahooLink { get; set; }

    //Addition/Update date
    public DateTime RegistrationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    //Product information edit 2
    public decimal AdditionalShippingFee { get; set; }
    public int Inventory { get; set; }
    public string? CatchCopy { get; set; }

    //edit view field
    public string? Option { get; set; }
    public string? ProductInformation { get; set; }
    public string? StoreCategory { get; set; }
    public string? ImageLink { get; set;}
}