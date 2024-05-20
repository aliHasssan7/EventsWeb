using EventsWeb122.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb122.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EventsWeb122.Data.ApplictionDbContext _context;

        public IndexModel(EventsWeb122.Data.ApplictionDbContext context)
        {
            _context = context;
        }

        public IList<Events> Events { get; set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Events.ToListAsync();
        }
    }
}
