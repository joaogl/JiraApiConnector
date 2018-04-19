using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Jira
{

    public class JiraSimplifiedIssue
    {

        public int Id { get; set; }
        public string Key { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string PriorityName { get; set; }
        public bool Done { get; set; }
        public string Assignee { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public CurrentEstimateStatistic CurrentEstimateStatistic { get; set; }

    }

}
