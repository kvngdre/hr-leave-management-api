namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException(string message) : ApplicationException(message)
{
}
