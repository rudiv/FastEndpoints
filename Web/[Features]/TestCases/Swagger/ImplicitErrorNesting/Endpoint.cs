namespace TestCases.Swagger.ImplicitErrorNesting;

public class EndpointA : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/implicit-error-nesting/a");
    }

    public override Task HandleAsync(CancellationToken c)
        => this.SendErrors();
}

public static class EndpointExtensions
{
    public static Task SendErrors(this IEndpoint endpoint)
        => endpoint.HttpContext.Response.SendErrorsAsync([]);
}