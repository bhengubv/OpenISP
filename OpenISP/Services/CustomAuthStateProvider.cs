public class CustomAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[] { new Claim("name", "TestUser") }, "Google");
        return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }
}
