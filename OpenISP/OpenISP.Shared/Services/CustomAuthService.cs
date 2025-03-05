using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenISP.Shared.Services
{
    public class CustomAuthService
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        public event Action OnAuthStateChanged;

        public ClaimsPrincipal GetCurrentUser()
        {
            return _currentUser;
        }

        public async Task LoginAsync(string userName)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName),
            }, "CustomAuth");

            _currentUser = new ClaimsPrincipal(identity);
            OnAuthStateChanged?.Invoke();
            await Task.CompletedTask; // Simulate async operation
        }

        public async Task LogoutAsync()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            OnAuthStateChanged?.Invoke();
            await Task.CompletedTask; // Simulate async operation
        }
    }
}