using JobBoard.WebAPI.Caching;
using JobBoard.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobBoard.WebAPI.Controllers
{
    public class JobsController : ApiController
    {
        // GET api/jobs
        public IHttpActionResult Get()
        {
            var jobs = SingletonCache.Instance.GetJobsFromCache();

            return Ok(jobs);
        }
    }
}
