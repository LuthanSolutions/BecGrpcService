namespace BecGrpcService.Services;

public class RunnerService : BecRunnerService.BecRunnerServiceBase
{
    private readonly IBecService becService;

    public RunnerService(IBecService becService) =>
        this.becService = becService;

    public override async Task<BecRunnerReply> ProcessBecDailyInput(Empty request, ServerCallContext context) =>
        await ProcessRequest(() => this.becService.ProcessBecDailyInputAsync());

    public override async Task<BecRunnerReply> ProcessGetBecEmailsToSend(Empty request, ServerCallContext context) =>
        await ProcessRequest(() => this.becService.ProcessGetBecEmailsToSendAsync());

    public override async Task<BecRunnerReply> ProcessBecSendEmails(Empty request, ServerCallContext context) => 
        await ProcessRequest(() => this.becService.ProcessBecSendEmailsAsync());

    private static async Task<BecRunnerReply> ProcessRequest(Func<Task<(bool Succeeded, string? ErrorMessage)>> processMethod)
    {
        var startMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
        try
        {
            var (Succeeded, ErrorMessage) = await processMethod();
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
                ErrorMessage = ex.Message,
                ExecutionTimeMilliseconds = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond - startMilliseconds
            };
        }
    }
}
