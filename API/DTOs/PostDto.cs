using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public string MediaUrl { get; set; }
        
        public ICollection<CommentDto> Comments { get; set; }

        public MemberDto AppUser { get; set; }
    }
}