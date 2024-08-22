﻿namespace NGOBackend.Helpers
{
    public class QueryObjectProject
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDescending {get; set; } = false;
    }
}
