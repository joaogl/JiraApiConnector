using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient.Models
{

    public class ApiResult<T>
    {

        public Exception Exception { get; set; }
        public T Result { get; set; }

    }

}
