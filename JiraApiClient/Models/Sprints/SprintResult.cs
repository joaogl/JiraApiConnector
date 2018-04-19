using JiraApiClient.Models.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Sprints
{

    public class SprintResult
    {

        public Sprint[] Sprints { get; set; }
        public int RapidViewId { get; set; }

    }

}
