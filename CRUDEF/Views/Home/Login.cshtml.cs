using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CRUDEF.Views.Home
{
    public class Login: PageModel
    {
        private readonly CPU0118Context DataBaseManager;
        public Login(CPU0118Context dbContext)
        {
            
           try  
            {
                // Settings.  
                this.DataBaseManager = dbContext;
            }  
            catch (Exception ex)  
            {  
                // Info  
                Console.Write(ex);  
            }  
        }
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }
        public IActionResult OnGet()
        {
            try
            {
                // Verification.  
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.  
                    return this.RedirectToPage("/Home/Index");
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.Page();
        }
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }
        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var loginInfo = await this.DataBaseManager.LoginByUsernamePasswordMethodAsync(this.LoginModel.Username, this.LoginModel.Password);
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.  
                        var logindetails = loginInfo.First();

                        // Login In.  
                        await this.SignInUser(logindetails.Username, false);

                        // Info.  
                        return this.RedirectToPage("/Home/Index");
                    }
                    else
                    {
                        // Setting.  
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }

                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }

            return this.Page();
        }

    }
}
