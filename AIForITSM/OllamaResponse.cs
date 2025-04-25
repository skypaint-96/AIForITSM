public class OllamaResponse
{
    public string Model { get; set; }
    public DateTime CreatedAt { get; set; }
    public OllamaMessage Message { get; set; }
    public string DoneReason { get; set; }
    public bool Done { get; set; }
}

public class OllamaMessage
{
    public string Role { get; set; }
    public string Content { get; set; }
}
