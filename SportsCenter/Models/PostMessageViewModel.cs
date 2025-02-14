﻿using SportsCenter.Controllers.Api;

namespace SportsCenter.Models
{
    public class PostMessageViewModel
    {
        public int Id { get; set; }
        public int Member_Id { get; set; }
        public int InviteCategory_Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }
        public string CreatedDate { get; set; }

        public IEnumerable<MessagesLoadingViewModel> Message { get; set; }
    }
}
