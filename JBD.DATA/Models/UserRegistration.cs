using JBD.DATA.Enums;

namespace JBD.DATA.Models;

public  class UserRegistration
{
    public int UserRegistrationId { get; set; }
    public string UserName { get; set; } = null!;
    public bool Validation { get; set; }
    public UserRoles Type { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
}