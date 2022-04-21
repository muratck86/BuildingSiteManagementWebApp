using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildingSiteManagementWebApp.Common.Constants;
using BuildingSiteManagementWebApp.Common.Helpers;
using BuildingSiteManagementWebApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BuildingSiteManagementWebApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage =TextsLang.IsRequired)]
            [Display(Name = TextsLang.Name)]
            public string Name  { get; set; }
            [Required(ErrorMessage = TextsLang.IsRequired)]
            [Display(Name =TextsLang.LastName)]
            public string LastName { get; set; }
            [Required(ErrorMessage = TextsLang.IsRequired)]
            [Display(Name=TextsLang.NationalId)]
            public string NationalId { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            user = await _userManager.FindByIdAsync(user.Id);
            Username = user.UserName;
            Input = _mapper.Map<InputModel>(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var name = user.Name;
            var lastName = user.LastName;
            var natId = user.NationalId;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            user.Name = Input.Name;
            user.LastName = Input.LastName;
            if (!ValidationHelper.IsValidNationalId(Input.NationalId))
            {
                StatusMessage = TextsLang.InvalidNationalId;
                return RedirectToPage();
            }
            user.NationalId = Input.NationalId;
            if (name == Input.Name && lastName == Input.LastName && natId == Input.NationalId)
            {
                StatusMessage = TextsLang.NothingChanged;
                return RedirectToPage();

            }
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = TextsLang.UnexpectedErrorUpdate;
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = TextsLang.UpdateSuccessful;
            return RedirectToPage();
        }
    }
}
