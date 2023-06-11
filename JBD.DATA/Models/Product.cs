using System.Runtime.InteropServices;

namespace JBD.DATA.Models;


//"productType": Integer,
//    "asin": String,
//    "title": String,
//    "lastPriceChange": Integer,
//    "imagesCSV": String,
//    "rootCategory": Integer,
//    "categories": Long array,
//    "categoryTree": Object array,
//    "manufacturer": String,
//    "brand": String,
//    "publicationDate": Integer,
//    "releaseDate": Integer,
//    "model": String,
//    "color": String,
//    "size": String,
//    "edition": String,
//    "format": String,
//    "features": String array,
//    "description": String,
//    "packageHeight": Integer,
//    "packageLength": Integer,
//    "packageWidth": Integer,
//    "packageWeight": Integer,
//    "packageQuantity": Integer,
//    "itemHeight": Integer,
//    "itemLength": Integer,
//    "itemWidth": Integer,
//    "itemWeight": Integer,
//    "isAdultProduct": Boolean,
//    "fbaFees": Object,



public class Product
{
    public int ProductId { get; set; }
    public int UserRegistrationId { get; set; }
    //Product info
    public string Asin { get; set; }
    public string ProductCode { get; set; }
    public string Brand { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }

    //Category/Size/Weight
    public int CategoryId { get; set; }
    public string Category { get; set; }
    public string Rank { get; set; }
    public decimal Size { get; set; }
    public decimal Weight { get; set; }

    //Pricing info
    public decimal PurchasePrice { get; set; }
    public decimal SalesPrice { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal GrossProfit { get; set; }

    //Amazon info
    public int NumberOfTimeSold { get; set; }
    public string AmazonJpLink { get; set; }
    public string OtherPurchasingSiteLink { get; set; }
    public string YahooLink { get; set; }

        
    //Addition/Update date
    public DateTime RegistrationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    //Product information edit 2
    public string AdditionalShippingFee { get; set; }
    public int Inventory { get; set; }
    public int CatchCopy { get; set; }

    //edit view field
    public string Option { get; set; }
    public string ProductInformation { get; set; }
    public string StoreCategory { get; set; }
     

    public UserRegistration UserRegistration { get; set; } = null!;
    public virtual ICollection<ProductImageLink> ProductImageLinks { get; set; }
}