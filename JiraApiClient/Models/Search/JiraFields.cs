using JiraApiClient.Models.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Search
{

    public sealed class JiraFields
    {

        public IssueType IssueType { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public JiraIssue[] SubTasks { get; set; }
        public string Summary { get; set; }
        public double customfield_10008 { get; set; }
        public Reporter Reporter { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? DueDate { get; set; }

    }

}
