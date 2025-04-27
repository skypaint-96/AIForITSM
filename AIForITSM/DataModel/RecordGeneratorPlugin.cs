namespace AIForITSM
{
    using Microsoft.SemanticKernel;
    //using Microsoft.SemanticKernel.SkillDefinition;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.SemanticKernel;
    using System.ComponentModel;
    using System.Text.Json;

    public class RecordGeneratorPlugin
    {
        [KernelFunction, Description("Serializes a collection of records (Problems, Incidents, or Users) into a JSON string.")]
        public string SerializeRecords<T>(
                [Description("The collection of records to serialize.")] IEnumerable<T> records)
        {
            return JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
        }

        [KernelFunction, Description("Creates a single Incident record.")]
        public async Task<Incident> CreateIncident(
                [Description("Unique identifier for the incident.")] string incidentId,
                [Description("Brief description of the incident.")] string shortDescription,
                [Description("Detailed description of the incident.")] string description,
                [Description("Priority of the incident (1 = Critical, 2 = High, 3 = Medium, 4 = Low).")] int priority,
                [Description("Current state of the incident (e.g., New, In Progress, Resolved, Closed).")] string state,
                [Description("The user assigned to resolve the incident.")] string assignedTo,
                [Description("The user who reported the incident.")] string callerId,
                [Description("Category of the incident (e.g., Network, Hardware, Software).")] string category,
                [Description("Subcategory of the incident.")] string subcategory,
                [Description("Timestamp when the incident was opened.")] DateTime openedAt,
                [Description("Timestamp when the incident was resolved.")] DateTime? resolvedAt,
                [Description("Timestamp when the incident was closed.")] DateTime? closedAt,
                [Description("Impact of the incident (1 = High, 2 = Medium, 3 = Low).")] int impact,
                [Description("Urgency of the incident (1 = High, 2 = Medium, 3 = Low).")] int urgency,
                [Description("Comments or updates related to the incident.")] string comments)
        {
            return new Incident
            {
                IncidentId = incidentId,
                ShortDescription = shortDescription,
                Description = description,
                Priority = priority,
                State = state,
                AssignedTo = assignedTo,
                CallerId = callerId,
                Category = category,
                Subcategory = subcategory,
                OpenedAt = openedAt,
                ResolvedAt = resolvedAt,
                ClosedAt = closedAt,
                Impact = impact,
                Urgency = urgency,
                Comments = comments
            };
        }

        [KernelFunction, Description("Creates a single Problem record.")]
        public async Task<Problem> CreateProblem(
            [Description("Unique identifier for the problem.")] string problemId,
            [Description("Brief description of the problem.")] string shortDescription,
            [Description("Detailed description of the problem.")] string description,
            [Description("Priority of the problem (1 = Critical, 2 = High, 3 = Medium, 4 = Low).")] int priority,
            [Description("Current state of the problem (e.g., New, In Progress, Resolved, Closed).")] string state,
            [Description("The user assigned to resolve the problem.")] string assignedTo,
            [Description("Timestamp when the problem was opened.")] DateTime openedAt,
            [Description("Timestamp when the problem was resolved.")] DateTime? resolvedAt,
            [Description("Timestamp when the problem was closed.")] DateTime? closedAt,
            [Description("Category of the problem (e.g., Network, Hardware, Software).")] string category,
            [Description("Impact of the problem (1 = High, 2 = Medium, 3 = Low).")] int impact,
            [Description("Urgency of the problem (1 = High, 2 = Medium, 3 = Low).")] int urgency,
            [Description("Root cause of the problem.")] string rootCause,
            [Description("Workaround for the problem, if available.")] string workaround,
            [Description("Comments or updates related to the problem.")] string comments)
        {
            return new Problem
            {
                ProblemId = problemId,
                ShortDescription = shortDescription,
                Description = description,
                Priority = priority,
                State = state,
                AssignedTo = assignedTo,
                OpenedAt = openedAt,
                ResolvedAt = resolvedAt,
                ClosedAt = closedAt,
                Category = category,
                Impact = impact,
                Urgency = urgency,
                RootCause = rootCause,
                Workaround = workaround,
                Comments = comments
            };
        }

        [KernelFunction, Description("Creates a single User record.")]
        public async Task<User> CreateUser(
            [Description("Unique identifier for the user.")] string userId,
            [Description("First name of the user.")] string firstName,
            [Description("Last name of the user.")] string lastName,
            [Description("Email address of the user.")] string email,
            [Description("Phone number of the user.")] string phone,
            [Description("Department the user belongs to.")] string department,
            [Description("Role of the user (e.g., Admin, IT Support, End User).")] string role,
            [Description("Indicates if the user is active.")] bool isActive,
            [Description("Timestamp when the user was created.")] DateTime createdAt,
            [Description("Timestamp of the user's last login.")] DateTime? lastLogin)
        {
            return new User
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Department = department,
                Role = role,
                IsActive = isActive,
                CreatedAt = createdAt,
                LastLogin = lastLogin
            };
        }

        [KernelFunction, Description("Adds a new record to a collection. If the collection is null, a new collection is created.")]
        public async Task<IEnumerable<T>> AddRecordToCollection<T>(
            [Description("The record to add to the collection.")] T record,
            [Description("The existing collection to add the record to. Can be null if there is no existing collection.")] IEnumerable<T>? collection)
        {
            var updatedCollection = collection?.ToList() ?? new List<T>();
            updatedCollection.Add(record);
            return updatedCollection;
        }
    }
}