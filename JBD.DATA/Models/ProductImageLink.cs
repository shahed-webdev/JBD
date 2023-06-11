namespace JBD.DATA.Models;

public class ProductImageLink
{
    public int ProductImageLinkId { get; set; }
    public int ProductId { get; set; }
    public string ImageLink { get; set; }                      
    public int DisplayOrder { get; set; }                      
    public Product Product { get; set; } = null!;
}