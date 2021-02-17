using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolJobAPI.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Job> ActualJobs { get; set; }

        public List<Job> GetActualJobs(int num)
        {
            return Jobs.ToList().Where((job,i) => i < 10*num).ToList();
        }
    }

}
