using JobBoard.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.WebAPI.Helpers
{
    public class JobComparer : IEqualityComparer<IJob>
    {
        public bool Equals(IJob x, IJob y)
        {
            return x.Id == y.Id && x.JobServiceName == y.JobServiceName;
        }

        public int GetHashCode(IJob obj)
        {
            return 0;
        }
    }
}