﻿namespace CVCreator.Domain.Entities.Models
{
    public class Experience
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public bool IsCurrent { get; set; }
    }
}
