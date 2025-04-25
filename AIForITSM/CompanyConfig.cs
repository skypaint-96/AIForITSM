public class CompanyConfig
{
    public AzureOpenAIConfig AzureOpenAI { get; set; }
    public OllamaConfig Ollama { get; set; }
}

public class AzureOpenAIConfig
{
    public string ApiKey { get; set; }
    public string Endpoint { get; set; }
    public string Model { get; set; }
    public string DeploymentName { get; set; }
}

public class OllamaConfig
{
    public string ApiKey { get; set; }
    public string Endpoint { get; set; }
    public string Model { get; set; }
}
