using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Data;
using ClassLibrary1.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ApplicationUser;

namespace WebApplication1.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
 
        public ProfileController(
            UserManager<ApplicationUser> userManager,
            IApplicationUser userService, 
            IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }

        public IActionResult Detail(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var model = new ProfileModel
            {
                userId = user.Id,
                Email = user.Email,
                MemberSince = user.MemberSince,
                ProfileImageUrl = user.ProfileImageUrl,
                UserName = user.UserName,
                UserRating = user.Rating.ToString()
            };
            return View(model);
        }
    }
}