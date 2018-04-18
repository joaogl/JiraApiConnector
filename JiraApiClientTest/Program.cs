using JiraApiClient.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClientTest
{

    class Program
    {

        static void Main(string[] args)
        {
            JiraApi.Instance.JiraAuthorize();

            using (SearchAgent agent = new SearchAgent(JiraApi.Instance))
            {
                var data = agent.Search("project = WEB AND issuetype = Bug AND status = \"To Do\" AND \"Epic Link\" = WEB-3826 ORDER BY priority DESC");
            }
        }

    }

}
