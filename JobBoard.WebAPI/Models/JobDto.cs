using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.WebAPI.Models
{
    public class JobDto : IJob
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string JobUrl { get; set; }
        public string JobServiceName { get; set; }
    }
}