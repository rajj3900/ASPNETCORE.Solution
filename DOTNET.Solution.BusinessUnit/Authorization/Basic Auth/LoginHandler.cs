using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Solution.BusinessUnit.Authorization.Basic_Auth
{
    public class LoginHandler
    {
        public static bool Login(string username, string password)
        {
            return (username == "raj" && password == "raj");
        }
    }
}
