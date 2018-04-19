using JiraApiClient.Models.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Sprints
{

    public class BoardResult
    {

        public BoardContents Contents { get; set; }
        public Sprint Sprint { get; set; }
        public bool SupportsPages { get; set; }

    }

}
