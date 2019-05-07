using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTable.UI.Areas.Admin.Models.DTO
{
    public class ArticleDTO
    {
        public Guid ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public Guid CategoryID  { get; set; }
        public Guid AppUserID { get; set; }
        public Guid FoodID { get; set; }
    }
}