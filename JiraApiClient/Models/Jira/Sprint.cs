using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models.Jira
{

    public class Sprint
    {

        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int LinkedPagesCount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DaysRemaining { get; set; }

    }

}
