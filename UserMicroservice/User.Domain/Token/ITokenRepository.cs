using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Token
{
    public interface ITokenRepository
    {
        TokenResult BuildToken(TokenMO x);
    }
}
