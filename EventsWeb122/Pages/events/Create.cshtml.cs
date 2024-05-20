using EventsWeb122.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsWeb122.Pages.events
{
    public class CreateModel : PageModel
    {
        private readonly EventsWeb122.Data.ApplictionDbContext _context;
        

        public CreateModel(EventsWeb122.Data.ApplictionDbContext context)
        {
            _context = context;
            
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Events Events { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            byte[] bytes = null;
            if (Events.ImageFile != null)
            {
                using (Stream fs = Events.ImageFile.OpenReadStream()) 
                {
                    using(BinaryReader br = new BinaryReader(fs)) 
                    { 
                        bytes=br.ReadBytes((Int32)fs.Length);
                    }
                }
                Events.ImgeUrl=Convert.ToBase64String(bytes,0,bytes.Length);
            }
            _context.Events.Add(Events);
            _context.SaveChanges();

         

            return RedirectToPage("./Index");
        }
    }
}