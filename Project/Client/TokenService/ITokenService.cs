using IdentityModel.Client;
using System.Threading.Tasks;

namespace TokensService
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
