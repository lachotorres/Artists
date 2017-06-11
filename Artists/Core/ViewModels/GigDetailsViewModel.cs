using Artists.Core.Models;
using System;

namespace Artists.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public Boolean IsAttending { get; set; }
        public Boolean IsFollowing { get; set; }
    }
}