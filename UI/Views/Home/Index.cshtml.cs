Bạn hoàn toàn đúng, tôi đã thiếu các file cshtml.cs tương ứng với các file trong thư mục Views. Dưới đây là chi tiết các file cshtml.cs tương ứng:

UI / Views / Account / Login.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ShoeStore.Shared.ViewModels;
using System.Threading.Tasks;

namespace ShoeStore.UI.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Login.UserName, Login.Password, Login.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}

UI / Views / Account / Register.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using ShoeStore.Shared.ViewModels;
using System.Threading.Tasks;

namespace ShoeStore.UI.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public RegisterViewModel Register { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Register.UserName, Email = Register.Email };
                var result = await _userManager.CreateAsync(user, Register.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }
    }
}

UI / Views / Home / Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoeStore.Shared.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShoeStore.UI.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<CategoryDto> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("api/categories");
        }
    }
}