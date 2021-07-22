using FileProcessor.Application.Models.Authentication;
using System.Threading.Tasks;

namespace FileProcessor.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
    }
}
