using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

public class Problem
{
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("activity_due")]
    public DateTime? ActivityDue { get; set; }

    [JsonPropertyName("additional_assignee_list")]
    public string? AdditionalAssigneeList { get; set; }

    [JsonPropertyName("approval")]
    public string? Approval { get; set; }

    [JsonPropertyName("approval_history")]
    public string? ApprovalHistory { get; set; }

    [JsonPropertyName("approval_set")]
    public string? ApprovalSet { get; set; }

    [JsonPropertyName("assigned_to")]
    public string? AssignedTo { get; set; }

    [JsonPropertyName("assignment_group")]
    public string? AssignmentGroup { get; set; }

    [JsonPropertyName("business_duration")]
    public string? BusinessDuration { get; set; }

    [JsonPropertyName("business_service")]
    public string? BusinessService { get; set; }

    [JsonPropertyName("calendar_duration")]
    public string? CalendarDuration { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("cause_notes")]
    public string? CauseNotes { get; set; }

    [JsonPropertyName("closed_at")]
    public DateTime? ClosedAt { get; set; }

    [JsonPropertyName("closed_by")]
    public string? ClosedBy { get; set; }

    [JsonPropertyName("close_notes")]
    public string? CloseNotes { get; set; }

    [JsonPropertyName("cmdb_ci")]
    public string? CmdbCi { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("comments_and_work_notes")]
    public string? CommentsAndWorkNotes { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("confirmed_at")]
    public DateTime? ConfirmedAt { get; set; }

    [JsonPropertyName("confirmed_by")]
    public string? ConfirmedBy { get; set; }

    [JsonPropertyName("contact_type")]
    public string? ContactType { get; set; }

    [JsonPropertyName("contract")]
    public string? Contract { get; set; }

    [JsonPropertyName("correlation_display")]
    public string? CorrelationDisplay { get; set; }

    [JsonPropertyName("correlation_id")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("duplicate_of")]
    public string? DuplicateOf { get; set; }

    [JsonPropertyName("escalation")]
    public string? Escalation { get; set; }

    [JsonPropertyName("expected_start")]
    public DateTime? ExpectedStart { get; set; }

    [JsonPropertyName("first_reported_by_task")]
    public string? FirstReportedByTask { get; set; }

    [JsonPropertyName("fix_at")]
    public DateTime? FixAt { get; set; }

    [JsonPropertyName("fix_by")]
    public DateTime? FixBy { get; set; }

    [JsonPropertyName("fix_communicated_at")]
    public DateTime? FixCommunicatedAt { get; set; }

    [JsonPropertyName("fix_communicated_by")]
    public string? FixCommunicatedBy { get; set; }

    [JsonPropertyName("fix_notes")]
    public string? FixNotes { get; set; }

    [JsonPropertyName("follow_up")]
    public DateTime? FollowUp { get; set; }

    [JsonPropertyName("group_list")]
    public string? GroupList { get; set; }

    [JsonPropertyName("impact")]
    public int? Impact { get; set; }

    [JsonPropertyName("knowledge")]
    public bool? Knowledge { get; set; }

    [JsonPropertyName("known_error")]
    public bool? KnownError { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("made_sla")]
    public bool? MadeSla { get; set; }

    [JsonPropertyName("major_problem")]
    public bool? MajorProblem { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; } // Required

    [JsonPropertyName("opened_at")]
    public DateTime OpenedAt { get; set; } // Required

    [JsonPropertyName("opened_by")]
    public string? OpenedBy { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    [JsonPropertyName("prb_model")]
    public string? PrbModel { get; set; }

    [JsonPropertyName("primary_known_error_article")]
    public string? PrimaryKnownErrorArticle { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("problem_state")]
    public string? ProblemState { get; set; }

    [JsonPropertyName("reassignment_count")]
    public int? ReassignmentCount { get; set; }

    [JsonPropertyName("related_incidents")]
    public string? RelatedIncidents { get; set; }

    [JsonPropertyName("reopened_at")]
    public DateTime? ReopenedAt { get; set; }

    [JsonPropertyName("reopened_by")]
    public string? ReopenedBy { get; set; }

    [JsonPropertyName("reopen_count")]
    public int? ReopenCount { get; set; }

    [JsonPropertyName("resolution_code")]
    public string? ResolutionCode { get; set; }

    [JsonPropertyName("resolved_at")]
    public DateTime? ResolvedAt { get; set; }

    [JsonPropertyName("resolved_by")]
    public string? ResolvedBy { get; set; }

    [JsonPropertyName("review_outcome")]
    public string? ReviewOutcome { get; set; }

    [JsonPropertyName("rfc")]
    public string? Rfc { get; set; }

    [JsonPropertyName("route_reason")]
    public string? RouteReason { get; set; }

    [JsonPropertyName("service_offering")]
    public string? ServiceOffering { get; set; }

    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; set; }

    [JsonPropertyName("skills")]
    public string? Skills { get; set; }

    [JsonPropertyName("sla_due")]
    public DateTime? SlaDue { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("subcategory")]
    public string? Subcategory { get; set; }

    [JsonPropertyName("sys_class_name")]
    public string? SysClassName { get; set; }

    [JsonPropertyName("sys_created_by")]
    public string? SysCreatedBy { get; set; }

    [JsonPropertyName("sys_created_on")]
    public DateTime? SysCreatedOn { get; set; }

    [JsonPropertyName("sys_domain")]
    public string? SysDomain { get; set; }

    [JsonPropertyName("sys_domain_path")]
    public string? SysDomainPath { get; set; }

    [JsonPropertyName("sys_id")]
    public string SysId { get; set; } // Required

    [JsonPropertyName("sys_mod_count")]
    public int? SysModCount { get; set; }

    [JsonPropertyName("sys_tags")]
    public string? SysTags { get; set; }

    [JsonPropertyName("sys_updated_by")]
    public string? SysUpdatedBy { get; set; }

    [JsonPropertyName("sys_updated_on")]
    public DateTime? SysUpdatedOn { get; set; }

    [JsonPropertyName("task_effective_number")]
    public string? TaskEffectiveNumber { get; set; }

    [JsonPropertyName("task_for")]
    public string? TaskFor { get; set; }

    [JsonPropertyName("time_worked")]
    public string? TimeWorked { get; set; }

    [JsonPropertyName("universal_request")]
    public string? UniversalRequest { get; set; }

    [JsonPropertyName("upon_approval")]
    public string? UponApproval { get; set; }

    [JsonPropertyName("upon_reject")]
    public string? UponReject { get; set; }

    [JsonPropertyName("urgency")]
    public int? Urgency { get; set; }

    [JsonPropertyName("user_input")]
    public string? UserInput { get; set; }

    [JsonPropertyName("u_customer_reference")]
    public string? UCustomerReference { get; set; }

    [JsonPropertyName("u_investigation_driver")]
    public string? UInvestigationDriver { get; set; }

    [JsonPropertyName("u_root_cause_code")]
    public string? URootCauseCode { get; set; }

    [JsonPropertyName("u_root_cause_date")]
    public DateTime? URootCauseDate { get; set; }

    [JsonPropertyName("u_template")]
    public string? UTemplate { get; set; }

    [JsonPropertyName("u_vendor_group")]
    public string? UVendorGroup { get; set; }

    [JsonPropertyName("u_vendor_reference")]
    public string? UVendorReference { get; set; }

    [JsonPropertyName("watch_list")]
    public string? WatchList { get; set; }

    [JsonPropertyName("workaround")]
    public string? Workaround { get; set; }

    [JsonPropertyName("workaround_applied")]
    public bool? WorkaroundApplied { get; set; }

    [JsonPropertyName("workaround_communicated_at")]
    public DateTime? WorkaroundCommunicatedAt { get; set; }

    [JsonPropertyName("workaround_communicated_by")]
    public string? WorkaroundCommunicatedBy { get; set; }

    [JsonPropertyName("work_end")]
    public DateTime? WorkEnd { get; set; }

    [JsonPropertyName("work_notes")]
    public string? WorkNotes { get; set; }

    [JsonPropertyName("work_notes_list")]
    public string? WorkNotesList { get; set; }

    [JsonPropertyName("work_start")]
    public DateTime? WorkStart { get; set; }

    // additional notes from during the review call, does not get imported from the ticket
    public string? PRBComments { get; set; }

    // Stores the last AI-generated update
    public string? ProblemUpdate { get; set; }

    public int GetAge()
    {
        return (DateTime.Now - OpenedAt).Days;
    }

    // Async AI-powered update summary for the last month
    public async Task<string> GetProblemUpdateAsync(Kernel kernel)
    {
        var problemData = new
        {
            Number,
            OpenedAt,
            State,
            Priority,
            ShortDescription,
            CauseNotes,
            Comments,
            WorkNotes,
            PRBComments,
            ProblemState,
            ResolvedAt,
            ClosedAt,
            SysUpdatedOn
        };

        string jsonData = JsonSerializer.Serialize(problemData);

        string prompt = $@"
You are an ITSM problem management assistant.
Analyze the following problem record and its comments/work notes.
Summarize the progress and setbacks for the last month in a concise update (2-4 sentences).
Focus on what has changed, any blockers, and next steps if relevant.

Problem Data (JSON):
{jsonData}
";

        var summarizeFunction = kernel.CreateFunctionFromPrompt(prompt);

        string result = string.Empty;
        await foreach (var item in summarizeFunction.InvokeStreamingAsync(kernel))
        {
            result += item.ToString();
        }

        return string.IsNullOrWhiteSpace(result)
            ? "No update could be generated for this problem."
            : result.Trim();
    }
}
