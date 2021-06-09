using System;

namespace API.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
          
        public UserCommentDto AppUser { get; set; }
    }
}