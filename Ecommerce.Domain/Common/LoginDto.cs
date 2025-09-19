using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Common;

public class LoginDto
{
    public string ToKen { get; set; }
    public User User { get; set;}
}
