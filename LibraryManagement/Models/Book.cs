﻿namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
       
        public int PublishedYear { get; set; }
        public int PageNumber { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
    }
}
