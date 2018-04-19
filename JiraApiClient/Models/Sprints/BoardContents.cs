using JiraApiClient.Models.Jira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Sprints
{

    public class BoardContents
    {

        public JiraSimplifiedIssue[] CompletedIssues { get; set; }
        public JiraSimplifiedIssue[] IssuesNotCompletedInCurrentSprint { get; set; }
        public JiraSimplifiedIssue[] IssuesCompletedInAnotherSprint { get; set; }
        public JiraSimplifiedIssue[] PuntedIssues { get; set; }

    }

}
