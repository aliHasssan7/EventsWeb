using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsWeb122.Data;
using EventsWeb122.Model;

namespace EventsWeb122.Pages.events
{
    public class DeleteModel : PageModel
    {
        private readonly EventsWeb122.Data.ApplictionDbContext _context;

        public DeleteModel(EventsWeb122.Data.ApplictionDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Events Events { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (Events == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events = await _context.Events.FindAsync(id);

            if (Events != null)
            {
                _context.Events.Remove(Events);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
