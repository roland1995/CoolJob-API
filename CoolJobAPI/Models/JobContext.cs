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

        public List<Job> GetActualJobs(int num)
        {
            return Jobs.ToList().Where((job,i) => i < 10*num).ToList();
        }

        public List<Job> GetFilteredJobs(string filterBy, string filterValue, int num)
        {
            string correctValue = filterValue.Replace("%20", " ");

            // Get the job object what have the specific property (variable) with the specific value
            List<Job> filtered = Jobs.ToList().Where(job => job.GetType().GetProperty(filterBy).GetValue(job).ToString() == correctValue).ToList();
            return filtered.Where((job, i) => i < 10 * num).ToList();
        }

        public HashSet<string> GetSpecificFilterValuesByFilterType(string filterBy)
        {
            // Get the unique filter values for the given filter type
            return Jobs.Select(job => job.GetType().GetProperty(filterBy).GetValue(job).ToString()).ToHashSet();
        }
    }

}
