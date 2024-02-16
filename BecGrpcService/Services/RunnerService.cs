namespace BecGrpcService.Services;
using BecGrpcService;
using Grpc.Core;
using System.Threading.Tasks;

public class RunnerService : BecRunnerService.BecRunnerServiceBase
{
    private readonly IBecService becService;

    public RunnerService(IBecService becService) =>
        this.becService = becService;

    public override async Task<BecRunnerReply> ProcessBecDailyInput(EmptyRequest request, ServerCallContext context)
    {
        try
        {
            var (Succeeded, ErrorMessage) = await this.becService.ProcessBecDailyInputAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage
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

    public override async Task<BecRunnerReply> ProcessGetBecEmailsToSend(EmptyRequest request, ServerCallContext context)
    {
        try
        {
            var (Succeeded, ErrorMessage) = await this.becService.ProcessGetBecEmailsToSendAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage
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

    public override async Task<BecRunnerReply> ProcessBecSendEmails(EmptyRequest request, ServerCallContext context)
    {
        try
        {
            var (Succeeded, ErrorMessage) = await this.becService.ProcessBecSendEmailsAsync();
            return new BecRunnerReply
            {
                Succeeded = Succeeded,
                ErrorMessage = ErrorMessage
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
