namespace Ecommerce.Domain.AppSettings;

public class KeycloakSettings
{
    public string AdminClientId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string Authority { get; set; } = string.Empty;
    public string TokenEndpoint { get; set; } = string.Empty;
    public string UserEndpoint { get; set; } = string.Empty;
    public string UserApiBase { get; set; } = string.Empty;
}
