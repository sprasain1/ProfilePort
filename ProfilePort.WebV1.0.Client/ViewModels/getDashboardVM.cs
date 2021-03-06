﻿using System.Collections.Generic;

namespace ProfilePort.ViewModels
{
    public class getDashboardVM
    {
        public string Id { get; set; }

        public string  DashboardName { get; set; }
       
        public virtual List<Note> Notes { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<Favorite> Favorites { get; set; }

        public virtual List<Interest> Interests { get; set; }

        public virtual List<Education> Educations { get; set; }

        public virtual List<Comment> Comments { get; set; }
        
        public virtual List<Job> Jobs { get; set; }

        public virtual List<Profile> Profile { get; set; }

    }
}