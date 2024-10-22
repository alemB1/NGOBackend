﻿namespace NGOBackend.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public ICollection<UserProject> UserProjects { get; set; }
    }
}
