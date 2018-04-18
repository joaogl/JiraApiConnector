using JiraApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClientTest
{

    class JiraApi : JiraAPIBase
    {

        private static readonly Lazy<JiraApi> lazy = new Lazy<JiraApi>(() => new JiraApi());

        public static JiraApi Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private JiraApi(string url, string user, string password) :
            base(url, user, password)
        {

        }

        private JiraApi() : this("https://jira.com/rest", "testing", "1234567")
        {

        }

        public JiraApi(string user, string password) : base(user, password)
        {

        }

    }

}
