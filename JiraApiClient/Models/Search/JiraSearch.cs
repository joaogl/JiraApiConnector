using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Search
{
    public sealed class JiraSearch
    {
        public string Expand { get; set; }
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }
        public JiraIssue[] Issues { get; set; }
    }

}
