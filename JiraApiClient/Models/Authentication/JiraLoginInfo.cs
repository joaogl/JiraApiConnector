using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models
{

    public sealed class JiraLoginInfo
    {
        public int FailedLoginCount { get; set; }
        public int LoginCount { get; set; }
        public string LastFailedLoginTime { get; set; }
        public string PreviousLoginTime { get; set; }
    }

}
