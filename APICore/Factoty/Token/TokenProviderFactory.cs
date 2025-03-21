﻿using APICore.AppSettings;
using Microsoft.Extensions.Options;

namespace APICore.Factoty.Token
{
    public class TokenProviderFactory
    {
        private readonly TokenSettings _tokenSettings;
        public TokenProviderFactory(IOptions<TokenSettings> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }
        public ITokenProvider GetTokenProvider(TokenProviderType provider)
        {
            switch (provider)
            {
                case TokenProviderType.Custom:
                    return new JwtTokenProvider(_tokenSettings);
               
            }

            throw new System.Exception("Token ProviderType is not available");
        }       
    }
}
