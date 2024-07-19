using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TokenServices
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(ApplicationUser appUser);
    }
}
