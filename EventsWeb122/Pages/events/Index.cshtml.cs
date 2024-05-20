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
    public class IndexModel : PageModel
    {
        private readonly EventsWeb122.Data.ApplictionDbContext _context;

        public IndexModel(EventsWeb122.Data.ApplictionDbContext context)
        {
            _context = context;
        }

        public IList<Events> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}
