using System.Text.Json.Serialization;

namespace DevSoc.Eventathon.Calendars.Google;

public class GoogleCredentialSettings
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }
    
    [JsonPropertyName("private_key_id")]
    public string? PrivateKeyId { get; set; }
    
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; set; }
    
    [JsonPropertyName("client_email")]
    public string? ClientEmail { get; set; }
    
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }
    
    [JsonPropertyName("auth_uri")]
    public string? AuthUri { get; set; }
    
    [JsonPropertyName("token_uri")]
    public string? TokenUri { get; set; }
    
    [JsonPropertyName("auth_provider_x509_cert_url")]
    public string? AuthProviderX509CertificateUrl { get; set; }
    
    [JsonPropertyName("client_x509_cert_url")]
    public string? ClientX509CertificateUrl { get; set; }

    public bool AreValid => !string.IsNullOrEmpty(Type) &&
                            !string.IsNullOrEmpty(ProjectId) &&
                            !string.IsNullOrEmpty(PrivateKeyId) &&
                            !string.IsNullOrEmpty(PrivateKey) &&
                            !string.IsNullOrEmpty(ClientEmail) &&
                            !string.IsNullOrEmpty(ClientId) &&
                            !string.IsNullOrEmpty(AuthUri) &&
                            !string.IsNullOrEmpty(TokenUri) &&
                            !string.IsNullOrEmpty(AuthProviderX509CertificateUrl) &&
                            !string.IsNullOrEmpty(ClientX509CertificateUrl);
}