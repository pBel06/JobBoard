using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobsBoardCRUD.Data;
using JobsBoardCRUD.Model;

namespace JobsBoardCRUD.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly JobsBoardCRUD.Data.JobsBoardCRUDContext _context;

        public CreateModel(JobsBoardCRUD.Data.JobsBoardCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobList JobList { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobList.Add(JobList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
