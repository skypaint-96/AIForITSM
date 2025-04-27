public class Problem
{
    public string ProblemId { get; set; } // Unique identifier for the problem
    public string ShortDescription { get; set; } // Brief description of the problem
    public string Description { get; set; } // Detailed description of the problem
    public int Priority { get; set; } // Priority of the problem (1 = Critical, 2 = High, 3 = Medium, 4 = Low)
    public string State { get; set; } // Current state of the problem (e.g., New, In Progress, Resolved, Closed)
    public string AssignedTo { get; set; } // The user assigned to resolve the problem
    public DateTime OpenedAt { get; set; } // Timestamp when the problem was opened
    public DateTime? ResolvedAt { get; set; } // Timestamp when the problem was resolved
    public DateTime? ClosedAt { get; set; } // Timestamp when the problem was closed
    public string Category { get; set; } // Category of the problem (e.g., Network, Hardware, Software)
    public int Impact { get; set; } // Impact of the problem (1 = High, 2 = Medium, 3 = Low)
    public int Urgency { get; set; } // Urgency of the problem (1 = High, 2 = Medium, 3 = Low)
    public string RootCause { get; set; } // Root cause of the problem
    public string Workaround { get; set; } // Workaround for the problem, if available
    public string Comments { get; set; } // Comments or updates related to the problem
}
