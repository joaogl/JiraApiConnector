using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Agent
{

    public class AgentBase : IDisposable
    {

        protected JiraAPIBase api { get; set; }

        public AgentBase(JiraAPIBase api)
        {
            this.api = api;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }

}
