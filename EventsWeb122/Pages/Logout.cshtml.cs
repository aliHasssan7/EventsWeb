using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsWeb122.Pages
{
  
    public class LogoutModel : PageModel
    {
		private readonly SignInManager<IdentityUser> signInManager;

		public LogoutModel(SignInManager<IdentityUser> signInManager)
		{
			this.signInManager = signInManager;
		}
		public void OnGet()
        {
        }
        public  IActionResult OnPost()
        {
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OnPostAsync(string returUrl = null)
		{
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OnPostLogOutAsync()
		{
			await signInManager.SignOutAsync();
            return RedirectToPage("Index");
            
		}

		public async Task <IActionResult> OnPostDontLogOutAsync()
		{
            return RedirectToPage("Index");
        }
	}
}
