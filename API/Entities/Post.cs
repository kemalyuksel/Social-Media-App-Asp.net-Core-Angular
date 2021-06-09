using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string MediaUrl { get; set; }
        
        public ICollection<Comment> Comments { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}