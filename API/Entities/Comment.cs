using System;

namespace API.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
          
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }
          
    }
}