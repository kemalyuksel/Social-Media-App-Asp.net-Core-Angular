using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class UserCommentDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
        public string KnownAs { get; set; }
        
    }
}