using APICore.Factoty.Token;

namespace APICore.Services.Token
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(TokenProviderType tokenProviderType, string userId, IEnumerable<string> roles = null);
    }
    public class TokenService : ITokenService
    {
        private readonly TokenProviderFactory _tokenProviderFactory;
        public TokenService(TokenProviderFactory tokenProviderFactory)
        {
            _tokenProviderFactory = tokenProviderFactory;
        }
        public async Task<string> GetTokenAsync(TokenProviderType tokenProviderType, string userId, IEnumerable<string> roles = null)
        { 

            var provider = _tokenProviderFactory.GetTokenProvider(tokenProviderType);
           return await provider.GenerateTokenAsync(userId);
        }
    }
}
