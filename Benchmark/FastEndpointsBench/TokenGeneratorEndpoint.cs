using FastEndpoints;
using FastEndpoints.Security;

namespace FEBench;

public class TokenGeneratorEndpoint : Endpoint<EmptyRequest, object>
{
    public override void Configure()
    {
        Get("/token-gen");
        AllowAnonymous();
    }

    public override Task HandleAsync(EmptyRequest _, CancellationToken __)
    {
        var token = JWTBearer.CreateToken(
            "some long secret key to sign jwt tokens with",
            p =>
            {
                p.Claims.Add(new("TestClaim", "TestValue"));
            });
        return SendAsync(token);
    }
}