namespace BecGrpcService;
public interface IBecService
{
    Task<(bool Succeeded, string? ErrorMessage)> ProcessBecDailyInputAsync();
    Task<(bool Succeeded, string? ErrorMessage)> ProcessGetBecEmailsToSendAsync();
    Task<(bool Succeeded, string? ErrorMessage)> ProcessBecSendEamilsAsync();
}

public class BecService
{
}
