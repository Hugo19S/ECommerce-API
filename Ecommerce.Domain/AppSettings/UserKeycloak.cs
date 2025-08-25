using System.Net;
using System.Text.Json.Serialization;

namespace Ecommerce.Domain.AppSettings
{
    public class Credential
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;

        [JsonPropertyName("temporary")]
        public bool Temporary { get; set; } = false;
    }

    public class UserKeycloak
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; set; } = true;

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonPropertyName("credentials")]
        public List<Credential> Credentials { get; set; } = new();
    };
}
