using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Search
{

    public sealed class JiraIssue
    {

        public int Id { get; set; }
        public string Key { get; set; }
        public JiraFields Fields { get; set; }

    }

}
