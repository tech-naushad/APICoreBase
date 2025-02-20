using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.Factoty.Token
{
    public interface ITokenProvider
    {
        Task<string> GenerateTokenAsync(string userId, IEnumerable<string> roles=null);
        Task<bool> ValidateTokenAsync(string token);
        Task<string> RefreshTokenAsync(string token);
    }
}
