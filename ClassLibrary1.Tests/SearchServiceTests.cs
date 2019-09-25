using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1.Data;
using ClassLibrary1.Data.Models;
using ClassLibrary1.Service;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClassLibrary1.Tests
{
    [TestFixture]
    public class Post_Service_Should
    {
        [TestCase("coffee", 3)]
        [TestCase("TeA", 1)]
        [TestCase("water", 0)]
        public void Return_Filtered_Results_Corresponding_To_Query(string query, int expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            //Arrange
            using (var ctx = new ApplicationDbContext(options))
            {
                ctx.Forums.Add(new Forum()
                {
                    Id = 19
                });

                ctx.Posts.Add(new Post()
                {
                    Forum = ctx.Forums.Find(19),
                    Id = 25553,
                    Title = "First Post",
                    Content = "Coffee"
                });

                ctx.Posts.Add(new Post()
                {
                    Forum = ctx.Forums.Find(19),
                    Id = -2224,
                    Title = "Coffee",
                    Content = "Some Content"
                });

                ctx.Posts.Add(new Post()
                {
                    Forum = ctx.Forums.Find(19),
                    Id = 223,
                    Title = "Tea",
                    Content = "Coffee"
                });

                ctx.SaveChanges();
            }

            //Act
            using (var ctx = new ApplicationDbContext(options))
            {
                var postService = new PostService(ctx);

                var result = postService.GetFilteredPosts(query);

                var postCount = result.Count();

                //Assert
                Assert.AreEqual(expected, postCount);
            }
        }
    }
}
