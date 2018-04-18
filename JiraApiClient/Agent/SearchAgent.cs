using JiraApiClient.Models;
using JiraApiClient.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Agent
{

    public class SearchAgent : AgentBase
    {

        public SearchAgent(JiraAPIBase api)
            : base(api)
        { }

        public JiraSearch Search(string jql)
        {
            ApiResult<JiraSearch> ret = new ApiResult<JiraSearch>();

            string urlParams = "/api/2/search?jql=" + jql;

            ret = this.api.Get<JiraSearch>(urlParams);

            if (ret.Exception != null)
                throw ret.Exception;

            return ret.Result;
        }

    }

}
