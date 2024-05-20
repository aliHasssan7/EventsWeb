using EventsWeb122.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.CodeDom;

namespace EventsWeb122.Pages
{
    public class LoginModel : PageModel
    {
		private readonly SignInManager<IdentityUser> signInManager;

		[BindProperty]
        public Login Model{ get; set; }

        public LoginModel(SignInManager<IdentityUser>signInManager) 
        {
			this.signInManager = signInManager;
		}

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returUrl = null) 
        {
            if(ModelState.IsValid) 
            {
              var identityResult = await  signInManager.PasswordSignInAsync(Model.Email, Model.password, Model.RememberMe, false);
                if (identityResult.Succeeded) 
                {
                    if(returUrl == null || returUrl == "/")
                    { 
                        return RedirectToPage("Index");
                    }
                    else
                    {
                      return RedirectToPage(returUrl);
                    }
                }
                ModelState.AddModelError("", "Username or password is roung  ");
            }
            return Page();

        }
    }
}
