namespace BecGrpcService;
public interface IBecService
{
    Task<(bool Succeeded, string? ErrorMessage)> ProcessBecDailyInputAsync();
    Task<(bool Succeeded, string? ErrorMessage)> ProcessGetBecEmailsToSendAsync();
    Task<(bool Succeeded, string? ErrorMessage)> ProcessBecSendEmailsAsync();
}

public class BecService : IBecService
{
    public Task<(bool Succeeded, string? ErrorMessage)> ProcessBecDailyInputAsync() => throw new NotImplementedException();
    public Task<(bool Succeeded, string? ErrorMessage)> ProcessBecSendEmailsAsync() => throw new NotImplementedException();
    public Task<(bool Succeeded, string? ErrorMessage)> ProcessGetBecEmailsToSendAsync() => throw new NotImplementedException();
}
