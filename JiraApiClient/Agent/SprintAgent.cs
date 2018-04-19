using JiraApiClient.Models;
using JiraApiClient.Models.Search;
using JiraApiClient.Models.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Agent
{

    public class SprintAgent : AgentBase
    {

        public SprintAgent(JiraAPIBase api)
            : base(api)
        { }

        public SprintResult GetAllSprintsFromRapidView(int rapidViewId, bool includeHistoricSprints = false, bool includeFutureSprints = false)
        {
            ApiResult<SprintResult> ret = new ApiResult<SprintResult>();

            string urlParams = "/greenhopper/1.0/sprintquery/" + rapidViewId;

            if (includeFutureSprints || includeHistoricSprints)
            {
                urlParams += "?";

                if (includeFutureSprints)
                {
                    urlParams += "includeFutureSprints=true";
                }

                if (includeFutureSprints && includeHistoricSprints)
                {
                    urlParams += "&";
                }

                if (includeHistoricSprints)
                {
                    urlParams += "includeHistoricSprints=true";
                }
            }

            ret = this.api.Get<SprintResult>(urlParams);

            if (ret.Exception != null)
                throw ret.Exception;

            return ret.Result;
        }

        public SprintIssuesResult GetAllSprintIssues(int boardId)
        {
            ApiResult<SprintIssuesResult> ret = new ApiResult<SprintIssuesResult>();

            string urlParams = "/agile/1.0/sprint/" + boardId + "/issue";

            ret = this.api.Get<SprintIssuesResult>(urlParams);

            if (ret.Exception != null)
                throw ret.Exception;

            return ret.Result;
        }

        public BoardResult GetSprintReport(int sprintId)
        {
            ApiResult<BoardResult> ret = new ApiResult<BoardResult>();

            string urlParams = "/greenhopper/1.0/rapid/charts/sprintreport?rapidViewId=19&sprintId="  + sprintId;

            ret = this.api.Get<BoardResult>(urlParams);

            if (ret.Exception != null)
                throw ret.Exception;

            return ret.Result;
        }

    }

}
