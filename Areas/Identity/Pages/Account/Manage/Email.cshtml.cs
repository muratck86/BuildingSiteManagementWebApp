using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using BuildingSiteManagementWebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Authorization;
using BuildingSiteManagementWebApp.Common.Constants;

namespace BuildingSiteManagementWebApp.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "User")]
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public EmailModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = TextsLang.IsRequired)]
            [EmailAddress]
            [Display(Name =TextsLang.Email)]
            public string NewEmail { get; set; }

            [Required(ErrorMessage = TextsLang.IsRequired)]
            [Phone]
            [Display (Name =TextsLang.Phone)]
            public string NewPhone { get; set; }
            [Required(ErrorMessage = TextsLang.IsRequired)]
            [Display(Name =TextsLang.Username)]
            public string NewUserName { get; set; }

        }

        private async Task LoadAsync(AppUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var phone = await _userManager.GetPhoneNumberAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
                NewPhone = phone,
                NewUserName = userName
            };

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

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            IdentityResult result;
            var email = await _userManager.GetEmailAsync(user);
            var phone = await _userManager.GetPhoneNumberAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);
            if (Input.NewEmail != email)
                user.Email = Input.NewEmail;
            if (Input.NewUserName != user.UserName)
                user.UserName = Input.NewUserName;
            if (Input.NewPhone != user.PhoneNumber)
                user.PhoneNumber = Input.NewPhone;
            if (Input.NewEmail != email || Input.NewPhone != phone || Input.NewUserName != userName)
            {
                result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                    StatusMessage = TextsLang.UnexpectedErrorUpdate;
                else
                    StatusMessage = TextsLang.UpdateSuccessful;
            }
            else StatusMessage = TextsLang.NothingChanged;
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
