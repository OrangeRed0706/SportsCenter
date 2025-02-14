﻿
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using SportsCenter.DataAccess;
//using SportsCenter.DataAccess.Entity;
//using SportsCenter.Models;
//using System.Security.Claims;
//using System.Xml.Linq;



//namespace SportsCenter.Controllers.Api
//{
//    [Route("/api/PostArticle/{action}")]
//    [ApiController]
//    public class PostArticleApiController : ControllerBase
//    {
//        private readonly SportsCenterDbContext dbContext;
//        public PostArticleApiController(SportsCenterDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }


//        [HttpGet]
//        public IEnumerable<Category> Get()
//        {
//            return dbContext.Category;
//        }

//        // POST api/<PostArticle>
//        [HttpPost]
//        public bool Post([FromBody] PostArticleCreateModel post)
//        {
//            var ID = (from a in dbContext.InviteCategory
//                      where a.Name == post.Type
//                      select a.Id).FirstOrDefault();
//            var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

//            dbContext.Posts.Add(new DataAccess.Entity.Post
//            {
//                InviteCategory_Id = 1,
//                Member_Id = 2,
//                Title = post.Title,
//                Content = post.Content,
//                CreatedDate = DateTime.Now,
//                IsActive = true,
//                ImagePath = "https://images-ext-1.discordapp.net/external/J49keTE-_qetwWIKr4YJ9AkFmNJYuE7JK3AQB4wuNHk/%3Fauto%3Dcompress%26cs%3Dtinysrgb%26w%3D1600/https/images.pexels.com/photos/1828525/pexels-photo-1828525.jpeg?width=396&height=594",
//            });
//            dbContext.SaveChanges();
//            return true;
//        }

//        [HttpGet]
//        public object GetAll()
//        {
//            return dbContext.Posts.Select(x => new {
//                x.InviteCategory_Id,
//                x.Member_Id,
//                x.Title,
//                x.Content,
//                x.CreatedDate,
//                x.ImagePath,

//            }).ToList();
//        }


//    }

//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;
using SportsCenter.Models;
using System.Security.Claims;

namespace SportsCenter.Controllers.Api
{
    [Route("api/PostArticle/{action}")]
    [ApiController]
    public class PostArticleApiController : ControllerBase
    {
        private readonly SportsCenterDbContext dbContext;
        public PostArticleApiController(SportsCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public bool Post([FromBody] PostArticleCreateModel post)
        {
            //var ID = (from a in dbContext.InviteCategory
            //          where a.Name == post.type
            //          select a.Id).FirstOrDefault();

            //var userid = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);

            dbContext.Posts.Add(new DataAccess.Entity.Post
            {
                IsActive = true,
                InviteCategory_Id = 1,
                Member_Id = 1,
                Title = post.Title,
                Content = post.Content,
                CreatedDate = DateTime.Now,
                ImagePath = "https://images.pexels.com/photos/1828525/pexels-photo-1828525.jpeg?auto=compress&cs=tinysrgb&w=1600",
            });
            dbContext.SaveChanges();

            return true;
        }


        [HttpGet]
        public object GetAll()
        {
            return dbContext.Posts.Select(x => new PostMessageViewModel
            {
                Id = x.Id,
                InviteCategory_Id = x.InviteCategory_Id,
                Member_Id = x.Member_Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate.ToString("yyyy/M/dd-HH:mm:ss"),
                ImagePath = x.ImagePath,

            }).ToList();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetDetail(int id)
        {
            var data = dbContext.Posts.Where(x => x.Id == id).Select(x => new PostMessageViewModel
            {
                Id = x.Id,
                InviteCategory_Id = x.InviteCategory_Id,
                Member_Id = x.Member_Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate.ToString("yyyy/M/dd-HH:mm:ss"),
                ImagePath = x.ImagePath,
                Message = x.Message.OrderBy(y => y.CreateDate).Select(y => new MessagesLoadingViewModel
                {
                    Id = y.Id,
                    Member_Id = y.Member_Id,
                    Body = y.Body,
                    Post_Id = y.Post_Id,
                    CreateDate = y.CreateDate.ToString("yyyy/M/dd-HH:mm:ss"),

                }).ToList(),
                //載入留言
            }).FirstOrDefault();

            return Ok(data);
        }

    }

  




}