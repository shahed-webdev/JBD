using System.Collections.Generic;

namespace JBD.DATA.Models;

public class ProductCategory
{
    //"domainId": Integer,
    //"catId": Long,
    //"name": String,
    //"contextFreeName": String,
    //"children": Long array,
    //"parent": Long,

    public int ProjectCategoryId { get; set; }
    public int CatId { get; set; }
    public int CategoryId { get; set; }
    public int ContextFreeName { get; set; }
    //List of all subcategories
    public string Children { get; set; }
    //If it is 0, the category is a root category
    public int Parent { get; set; }
}