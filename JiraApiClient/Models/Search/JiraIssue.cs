using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Search
{

    public class JiraIssue
    {

        public int Id { get; set; }
        public string Key { get; set; }
        public string Expand { get; set; }
        public string Self { get; set; }
        public JiraFields Fields { get; set; }

    }

}
