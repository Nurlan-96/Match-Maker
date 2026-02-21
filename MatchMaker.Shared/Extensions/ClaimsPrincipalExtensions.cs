using System.Security.Claims;

namespace MatchMaker.Shared.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var claim = user.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null)
            throw new InvalidOperationException("User ID claim is missing.");

        return Guid.Parse(claim.Value);
    }
}