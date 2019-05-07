﻿using FoodTable.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTable.Model.Option
{
    public class Article:CoreEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public Guid AppUserID  { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Like> Likes { get; set; }

        public virtual List<Comment> Comments { get; set; }

        


    }
}
