using EventsWeb122.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EventsWeb122.Pages
{
    public class RegisterModel : PageModel
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public Users Model { get; set; }

		public RegisterModel(UserManager<IdentityUser>userManager,SignInManager<IdentityUser>signInManager)
		{
		    _userManager = userManager;
			_signInManager = signInManager;
		}



        
        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPostAsync() 
        {
            if(ModelState.IsValid) 
            {
				var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };
				var result = await _userManager.CreateAsync(user, Model.Password);
                
                if (result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("Privacy");

                }


                foreach(var error in result.Errors) 
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return Page();

        }    
      
    }
}
