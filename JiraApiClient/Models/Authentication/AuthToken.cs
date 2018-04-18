using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models
{

    public sealed class AuthToken
    {
        public JiraSession Session { get; set; }
        public JiraLoginInfo LoginInfo { get; set; }
    }

}
