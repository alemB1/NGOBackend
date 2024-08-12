﻿namespace NGOBackend.Models
{
    public class UserProject
    {
        public int UserId { get; set; }
        public User User { get; set; } = null;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null;
    }
}
