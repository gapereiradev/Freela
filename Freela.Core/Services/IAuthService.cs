using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Core.Services
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string email, string role);
        public string ComputeSha256Hash(string password);
    }
}
