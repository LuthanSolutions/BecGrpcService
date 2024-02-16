namespace BecGrpcService.Services;

public class RunnerService : BecRunnerService.BecRunnerServiceBase
{
    private readonly IBecService becService;

    public RunnerService(IBecService becService) =>
        this.becService = becService;

    public override async Task<BecRunnerReply> ProcessBecDailyInput(Empty request, ServerCallContext context)
    {
        try
        {
            var startMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            var (Succeeded, ErrorMessage) = await this.becService.ProcessBecDailyInputAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage,
                ExecutionTimeMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - startMilliseconds
            };
        }
        catch (Exception ex)
        {
            return new BecRunnerReply
            {
                Succeeded = false,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<BecRunnerReply> ProcessGetBecEmailsToSend(Empty request, ServerCallContext context)
    {
        try
        {
            var startMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            var (Succeeded, ErrorMessage) = await this.becService.ProcessGetBecEmailsToSendAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage,
                ExecutionTimeMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - startMilliseconds
            };
        }
        catch (Exception ex)
        {
            return new BecRunnerReply
            {
                Succeeded = false,
                ErrorMessage = ex.Message
            };
        }
    }

    public override async Task<BecRunnerReply> ProcessBecSendEmails(Empty request, ServerCallContext context)
    {
        try
        {
            var startMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            var (Succeeded, ErrorMessage) = await this.becService.ProcessBecSendEmailsAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage,
                ExecutionTimeMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - startMilliseconds
            };
        }
        catch (Exception ex)
        {
            return new BecRunnerReply
            {
                Succeeded = false,
                ErrorMessage = ex.Message
            };
        }
    }
}
