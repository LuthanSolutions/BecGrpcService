namespace BecGrpcServiceTests;

using BecGrpcService;
using BecGrpcService.Services;
using Moq;

public class RunnerServiceTests
{
    private readonly Mock<IBecService> mockBecService;

    public RunnerServiceTests() =>
        this.mockBecService = new();

    [Fact]
    public async Task ProcessBecDailyInput_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessBecDailyInput(new EmptyRequest(), null!);

        this.mockBecService.Verify(svc => svc.ProcessBecDailyInputAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(true, "")]
    [InlineData(true, "Some text as error message")]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "Some text as error message")]
    public async Task ProcessBecDailyInput_ReturnsCorrectValue(bool succeeded, string? errorMessage)
    {
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecDailyInput(new EmptyRequest(), null!);

        response.Succeeded = succeeded;
        response.ErrorMessage = errorMessage;
    }

    [Fact]
    public async Task ProcessGetBecEmailsToSend_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessGetBecEmailsToSend(new EmptyRequest(), null!);

        this.mockBecService.Verify(svc => svc.ProcessGetBecEmailsToSendAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(true, "")]
    [InlineData(true, "Some text as error message")]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "Some text as error message")]
    public async Task ProcessGetBecEmailsToSend_ReturnsCorrectValue(bool succeeded, string? errorMessage)
    {
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessGetBecEmailsToSend(new EmptyRequest(), null!);

        response.Succeeded = succeeded;
        response.ErrorMessage = errorMessage;
    }

    [Fact]
    public async Task ProcessBecSendEamils_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessBecSendEamils(new EmptyRequest(), null!);

        this.mockBecService.Verify(svc => svc.ProcessBecSendEamilsAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(true, "")]
    [InlineData(true, "Some text as error message")]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(false, "Some text as error message")]
    public async Task ProcessBecSendEamils_ReturnsCorrectValue(bool succeeded, string? errorMessage)
    {
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecSendEamils(new EmptyRequest(), null!);

        response.Succeeded = succeeded;
        response.ErrorMessage = errorMessage;
    }
}