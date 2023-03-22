using System.ComponentModel;

namespace JBD.DATA.Enums;

public enum UserRoles
{
    Unknown,
    [Description("Super-Admin")]
    SuperAdmin,
    Admin,
    Seller,

}