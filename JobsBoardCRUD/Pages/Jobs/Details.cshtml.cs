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
    public class DetailsModel : PageModel
    {
        private readonly JobsBoardCRUD.Data.JobsBoardCRUDContext _context;

        public DetailsModel(JobsBoardCRUD.Data.JobsBoardCRUDContext context)
        {
            _context = context;
        }

        public JobList JobList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobList = await _context.JobList.FirstOrDefaultAsync(m => m.ID == id);

            if (JobList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
