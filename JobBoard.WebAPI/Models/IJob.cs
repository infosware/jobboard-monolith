using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.WebAPI.Models
{
    public interface IJob
    {
        string Id { get; set; }
        string Title { get; set; }
        string CompanyName { get; set; }
        string JobUrl { get; set; }
        string JobServiceName { get; set; }
    }
}
