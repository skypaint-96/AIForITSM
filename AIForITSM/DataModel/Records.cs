namespace AIForITSM
{
    /// <summary>
    /// Represents the response from the Ollama API.
    /// </summary>
    public class OllamaResponse
    {
        public string Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public OllamaMessage Message { get; set; }
        public string DoneReason { get; set; }
        public bool Done { get; set; }
    }

    /// <summary>
    /// Represents a message in the Ollama API response.
    /// </summary>
    public class OllamaMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Represents the configuration for a company.
    /// </summary>
    public class CompanyConfig
    {
        public AzureOpenAIConfig AzureOpenAI { get; set; }
        public OllamaConfig Ollama { get; set; }
    }

    /// <summary>
    /// Represents the configuration for Azure OpenAI.
    /// </summary>
    public class AzureOpenAIConfig
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string Model { get; set; }
        public string DeploymentName { get; set; }
    }

    /// <summary>
    /// Represents the configuration for Ollama.
    /// </summary>
    public class OllamaConfig
    {
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string Model { get; set; }
    }
}