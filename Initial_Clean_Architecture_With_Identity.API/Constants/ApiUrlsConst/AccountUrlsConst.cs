using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initial_Clean_Architecture_With_Identity.API.Constants.ApiUrlsConst
{
    public class AccountUrlsConst
    {
        private const string _controller = "account";
        internal const string Register = $"{_controller}/register";
        internal const string Login = $"{_controller}/login";
    }
}
