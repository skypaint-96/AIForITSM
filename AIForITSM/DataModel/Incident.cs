public class Incident
{
    public string IncidentId { get; set; } // Unique identifier for the incident
    public string ShortDescription { get; set; } // Brief description of the incident
    public string Description { get; set; } // Detailed description of the incident
    public int Priority { get; set; } // Priority of the incident (1 = Critical, 2 = High, 3 = Medium, 4 = Low)
    public string State { get; set; } // Current state of the incident (e.g., New, In Progress, Resolved, Closed)
    public string AssignedTo { get; set; } // The user assigned to resolve the incident
    public string CallerId { get; set; } // The user who reported the incident
    public string Category { get; set; } // Category of the incident (e.g., Network, Hardware, Software)
    public string Subcategory { get; set; } // Subcategory of the incident
    public DateTime OpenedAt { get; set; } // Timestamp when the incident was opened
    public DateTime? ResolvedAt { get; set; } // Timestamp when the incident was resolved
    public DateTime? ClosedAt { get; set; } // Timestamp when the incident was closed
    public int Impact { get; set; } // Impact of the incident (1 = High, 2 = Medium, 3 = Low)
    public int Urgency { get; set; } // Urgency of the incident (1 = High, 2 = Medium, 3 = Low)
    public string Comments { get; set; } // Comments or updates related to the incident
}
