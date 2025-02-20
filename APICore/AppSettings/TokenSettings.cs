using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICore.AppSettings
{
    public class TokenSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan ExpirationTime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
