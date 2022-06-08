using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Auth.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
       
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secrets()
        {
            return View();  
        }

        public IActionResult Authenticate()
        {

            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Akansha"),
                new Claim(ClaimTypes.MobilePhone,"9412647618"),
                new Claim("Grandma.Says","Very cool boi."),
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Akansha Verma"),
                new Claim("DrivingLicence", "A+"),
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
