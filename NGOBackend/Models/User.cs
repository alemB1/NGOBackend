﻿namespace NGOBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public ICollection<UserProject> UserProjects { get; set; }
    }
}
