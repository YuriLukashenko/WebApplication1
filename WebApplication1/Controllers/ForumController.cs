using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Data;
using ClassLibrary1.Data.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Forum;

namespace WebApplication1.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description
                });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };
                
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
        }
    }
}