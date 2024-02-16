namespace BecGrpcServiceTests;

public class RunnerServiceTests
{
    private readonly Mock<IBecService> mockBecService;

    public RunnerServiceTests() =>
        this.mockBecService = new();

    [Fact]
    public async Task ProcessBecDailyInput_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessBecDailyInput(new Empty(), null!);

        this.mockBecService.Verify(svc => svc.ProcessBecDailyInputAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null, 123)]
    [InlineData(true, "", 321)]
    [InlineData(true, "Some text as error message", 246)]
    [InlineData(false, null, 135)]
    [InlineData(false, "", 987)]
    [InlineData(false, "Some text as error message", 654)]
    public async Task ProcessBecDailyInput_ReturnsCorrectValue(bool succeeded, string? errorMessage, int milliseconds)
    {
        _ = this.mockBecService
            .Setup(svc => svc.ProcessBecDailyInputAsync())
            .Callback(() => Thread.Sleep(milliseconds))
            .ReturnsAsync((succeeded, errorMessage));
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecDailyInput(new Empty(), null!);

        _ = response.Succeeded.Should().Be(succeeded);
        _ = response.ErrorMessage.Should().Be(errorMessage);
        _ = response.ExecutionTimeMilliseconds.Should().BeGreaterThanOrEqualTo(milliseconds);
    }

    [Fact]
    public async Task ProcessBecDailyInput_BecServiceCallThrowsException_ReturnsCorrectReply()
    {
        var expectedExceptionMessage = "Something went wrong";
        var expectedException = new Exception(expectedExceptionMessage);
        _ = this.mockBecService
            .Setup(svc => svc.ProcessBecDailyInputAsync())
            .Throws(expectedException);
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecDailyInput(new Empty(), null!);

        _ = response.Succeeded.Should().Be(false);
        _ = response.ErrorMessage.Should().Be(expectedExceptionMessage);
    }

    [Fact]
    public async Task ProcessGetBecEmailsToSend_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessGetBecEmailsToSend(new Empty(), null!);

        this.mockBecService.Verify(svc => svc.ProcessGetBecEmailsToSendAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null, 123)]
    [InlineData(true, "", 321)]
    [InlineData(true, "Some text as error message", 246)]
    [InlineData(false, null, 135)]
    [InlineData(false, "", 987)]
    [InlineData(false, "Some text as error message", 654)]
    public async Task ProcessGetBecEmailsToSend_ReturnsCorrectValue(bool succeeded, string? errorMessage, int milliseconds)
    {
        _ = this.mockBecService
            .Setup(svc => svc.ProcessGetBecEmailsToSendAsync())
            .Callback(() => Thread.Sleep(milliseconds))
            .ReturnsAsync((succeeded, errorMessage));
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessGetBecEmailsToSend(new Empty(), null!);

        _ = response.Succeeded.Should().Be(succeeded);
        _ = response.ErrorMessage.Should().Be(errorMessage);
        _ = response.ExecutionTimeMilliseconds.Should().BeGreaterThanOrEqualTo(milliseconds);
    }

    [Fact]
    public async Task ProcessGetBecEmailsToSend_BecServiceCallThrowsException_ReturnsCorrectReply()
    {
        var expectedExceptionMessage = "Something went wrong";
        var expectedException = new Exception(expectedExceptionMessage);
        _ = this.mockBecService
            .Setup(svc => svc.ProcessGetBecEmailsToSendAsync())
            .Throws(expectedException);
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessGetBecEmailsToSend(new Empty(), null!);

        _ = response.Succeeded.Should().Be(false);
        _ = response.ErrorMessage.Should().Be(expectedExceptionMessage);
    }

    [Fact]
    public async Task ProcessBecSendEmails_CallsServicesCorrectly()
    {
        var sut = new RunnerService(this.mockBecService.Object);

        _ = await sut.ProcessBecSendEmails(new Empty(), null!);

        this.mockBecService.Verify(svc => svc.ProcessBecSendEmailsAsync(), Times.Once());
        this.mockBecService.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData(true, null, 123)]
    [InlineData(true, "", 321)]
    [InlineData(true, "Some text as error message", 246)]
    [InlineData(false, null, 135)]
    [InlineData(false, "", 987)]
    [InlineData(false, "Some text as error message", 654)]
    public async Task ProcessBecSendEmails_ReturnsCorrectValue(bool succeeded, string? errorMessage, int milliseconds)
    {
        _ = this.mockBecService
            .Setup(svc => svc.ProcessBecSendEmailsAsync())
            .Callback(() => Thread.Sleep(milliseconds))
            .ReturnsAsync((succeeded, errorMessage));
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecSendEmails(new Empty(), null!);

        _ = response.Succeeded.Should().Be(succeeded);
        _ = response.ErrorMessage.Should().Be(errorMessage);
        _ = response.ExecutionTimeMilliseconds.Should().BeGreaterThanOrEqualTo(milliseconds);
    }

    [Fact]
    public async Task ProcessBecSendEmails_BecServiceCallThrowsException_ReturnsCorrectReply()
    {
        var expectedExceptionMessage = "Something went wrong";
        var expectedException = new Exception(expectedExceptionMessage);
        _ = this.mockBecService
            .Setup(svc => svc.ProcessBecSendEmailsAsync())
            .Throws(expectedException);
        var sut = new RunnerService(this.mockBecService.Object);

        var response = await sut.ProcessBecSendEmails(new Empty(), null!);

        _ = response.Succeeded.Should().Be(false);
        _ = response.ErrorMessage.Should().Be(expectedExceptionMessage);
    }
}