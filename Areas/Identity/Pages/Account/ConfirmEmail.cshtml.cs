using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildingSiteManagementWebApp.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("Login");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Login");
        }
    }
}
