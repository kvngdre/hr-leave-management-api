namespace HR.LeaveManagement.Application.Responses;

public class BaseCommandResponse
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; }
    public int Id { get; set; }
}
