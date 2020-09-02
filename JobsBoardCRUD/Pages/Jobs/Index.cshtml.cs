using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobsBoardCRUD.Data;
using JobsBoardCRUD.Model;

namespace JobsBoardCRUD.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly JobsBoardCRUD.Data.JobsBoardCRUDContext _context;

        public IndexModel(JobsBoardCRUD.Data.JobsBoardCRUDContext context)
        {
            _context = context;
        }

        public IList<JobList> JobList { get;set; }

        public async Task OnGetAsync()
        {
            JobList = await _context.JobList.ToListAsync();
        }
    }
}
