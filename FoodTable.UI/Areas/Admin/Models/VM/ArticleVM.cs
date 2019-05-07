using FoodTable.Model.Option;
using FoodTable.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTable.UI.Areas.Admin.Models.VM
{
    public class ArticleVM
    {
        public ArticleVM()
        {
            Categories = new List<Category>();
            AppUsers = new List<AppUser>();
            appUser = new AppUser();
           
            article = new ArticleDTO();
        }
        public List<Category> Categories { get; set; }
        public List<AppUser> AppUsers { get; set; }        
        public ArticleDTO article { get; set; }
        public AppUser appUser { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}