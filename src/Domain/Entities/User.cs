namespace Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string? PasswordHash { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
