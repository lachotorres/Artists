﻿using Artists.Core.Models;
using System;

namespace Artists.Core.Dtos
{
    public class NotificationDto
    {
        
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }        
        public GigDto Gig { get; set; }
    }
}