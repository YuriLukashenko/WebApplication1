using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Data;
using ClassLibrary1.Data.Models;
using Microsoft.AspNetCore.Http;
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
            var user = _userService.GetById(id);

            var userRoles = _userManager.GetRolesAsync(user).Result;

            var model = new ProfileModel
            {
                userId = user.Id,
                Email = user.Email,
                MemberSince = user.MemberSince,
                ProfileImageUrl = user.ProfileImageUrl,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadProfileImage(IFormFile file)
        //{
        //    var user_id = _userManager.GetUserId(User);
        //    //Connect to azure storage
        //    //Get Blob Container

        //    //Parse the Content Disposition responce header
        //    //Grab the filename

        //    //Get a reference to a Block Blob
        //    //On the Block Blob upload the file <- file uploaded to the cloud

        //    //Set the User's profile image to the URI
        //    //redirect to the user's profile page
       

        //}

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(user => user.Rating)
                .Select(u => new ProfileModel
                {
                    Email = u.Email,
                    UserName = u.UserName,
                    ProfileImageUrl = u.ProfileImageUrl,
                    UserRating = u.Rating.ToString(),
                    MemberSince = u.MemberSince
                });

            var model = new ProfileListModel
            {
                Profiles = profiles
            };

            return View(model);
        }
    }
}