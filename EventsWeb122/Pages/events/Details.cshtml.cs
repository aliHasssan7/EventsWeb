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
    public class DetailsModel : PageModel
    {
        private readonly EventsWeb122.Data.ApplictionDbContext _context;

        public DetailsModel(EventsWeb122.Data.ApplictionDbContext context)
        {
            _context = context;
        }

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
    }
}
