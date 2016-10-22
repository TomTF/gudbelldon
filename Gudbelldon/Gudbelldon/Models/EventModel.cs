using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gudbelldon.Models
{
    public class EventModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan? End { get; set; }

        public EventModel()
        {

        }

        public EventModel(string imageUrl, string title, string subtitle, string description, DateTime date, TimeSpan start, TimeSpan? end)
        {
            this.ImageUrl = imageUrl;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Date = date;
            this.Description = description;
            this.Start = start;
            this.End = end;
        }
    }
}