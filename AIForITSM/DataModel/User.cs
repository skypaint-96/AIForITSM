public class User
{
    public string UserId { get; set; } // Unique identifier for the user
    public string FirstName { get; set; } // First name of the user
    public string LastName { get; set; } // Last name of the user
    public string Email { get; set; } // Email address of the user
    public string Phone { get; set; } // Phone number of the user
    public string Department { get; set; } // Department the user belongs to
    public string Role { get; set; } // Role of the user (e.g., Admin, IT Support, End User)
    public bool IsActive { get; set; } // Indicates if the user is active
    public DateTime CreatedAt { get; set; } // Timestamp when the user was created
    public DateTime? LastLogin { get; set; } // Timestamp of the user's last login
}
