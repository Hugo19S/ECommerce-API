namespace Ecommerce.Domain.AppSettings
{
    public class KeycloakSettings
    {
        public string AdminClientId { get; set; } = string.Empty;
        public string AdminUsername { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
        public string TokenEndpoint { get; set; } = string.Empty;
        public string UserApiBase { get; set; } = string.Empty;
    }
}
