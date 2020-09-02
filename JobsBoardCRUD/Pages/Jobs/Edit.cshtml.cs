using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobsBoardCRUD.Data;
using JobsBoardCRUD.Model;

namespace JobsBoardCRUD.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly JobsBoardCRUD.Data.JobsBoardCRUDContext _context;

        public EditModel(JobsBoardCRUD.Data.JobsBoardCRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobListExists(JobList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobListExists(int id)
        {
            return _context.JobList.Any(e => e.ID == id);
        }
    }
}
