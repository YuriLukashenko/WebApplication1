﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ApplicationUser
{
    public class ProfileModel
    {
        public string userId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserRating { get; set; }
        public string ProfileImageUrl { get; set; }

        public DateTime MemberSince { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
