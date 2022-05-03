using Authenticate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Services
{
    public interface IJWTManagerInterface
    {
        Tokens Authenticate(User users);
    }
}
