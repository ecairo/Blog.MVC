using AutoMapper;
using Blog.Entities;
using Blog.Service;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;
        private readonly ILog logger;
        private IAuthenticationManager authenticationManager;

        public AccountController(UserManager<ApplicationUser> userManager, IAuthorService authorService,
            IMapper mapper, ILog logger)
        {
            this.userManager = userManager;
            this.authorService = authorService;
            this.mapper = mapper;
            this.logger = logger;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ViewModels.LoginViewModel loginViewModel, string returnUrl)
        {
            this.logger.Info("Entering Login Action");

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            var user = await this.userManager.FindAsync(loginViewModel.Email, loginViewModel.Password);
            this.logger.Info("User Authenticated: " + loginViewModel.Email);

            if (user != null)
            {
                await this.SignInAsync(user, loginViewModel.RememberMe);

                this.logger.Info("User Identity Cookie Generated: " + loginViewModel.Email);

                return RedirectToLocal(returnUrl);
                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        return RedirectToLocal(returnUrl);
                //    case SignInStatus.LockedOut:
                //        return View("Lockout");
                //    case SignInStatus.RequiresVerification:
                //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                //    case SignInStatus.Failure:
                //    default:
                //        ModelState.AddModelError("", "Invalid login attempt.");
                //        return View(model);
                //}
            }

            return View(loginViewModel);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ViewModels.RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new ApplicationUser() { UserName = registerViewModel.Email, Email = registerViewModel.Email };

            var result = await this.userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                var userId = user.Id;
                // var userName = user.UserName;

                var authorEntity = this.mapper.Map<ViewModels.RegisterViewModel, Entities.Author>(registerViewModel);

                authorEntity.Id = Guid.NewGuid();
                authorEntity.UserId = userId;

                this.authorService.AddAuthor(authorEntity);
                this.authorService.Commit();

                await SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await this.userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                if (this.authenticationManager == null)
                {
                    this.authenticationManager = HttpContext.GetOwinContext().Authentication;
                }                    
                return this.authenticationManager;
            }
            set { this.authenticationManager = value; }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = await this.userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}