using JobBoard.WebAPI.Helpers;
using JobBoard.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.WebAPI.Caching
{
    public sealed class SingletonCache
    {
        private static SingletonCache instance = null;
        private static readonly object padlock = new object();
        private readonly List<IJob> jobs;

        private SingletonCache()
        {
            jobs = new List<IJob>();
        }

        public static SingletonCache Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonCache();
                    }
                    return instance;
                }
            }
        }

        public void AddJobsToCache(List<IJob> jobsChunk)
        {
            var newJobs = jobsChunk
                .Except(jobs, new JobComparer())
                .ToList();

            jobs.AddRange(newJobs);
        }

        public List<IJob> GetJobsFromCache()
        {
            return jobs;
        }
    }
}