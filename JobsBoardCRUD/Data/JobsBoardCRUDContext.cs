using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobsBoardCRUD.Model;

namespace JobsBoardCRUD.Data
{
    public class JobsBoardCRUDContext : DbContext
    {
        public JobsBoardCRUDContext (DbContextOptions<JobsBoardCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<JobsBoardCRUD.Model.JobList> JobList { get; set; }
    }
}
