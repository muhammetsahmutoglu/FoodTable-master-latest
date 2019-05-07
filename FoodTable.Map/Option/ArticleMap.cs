using FoodTable.Core.Map;
using FoodTable.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTable.Map.Option
{
   public class ArticleMap:CoreMap<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Articles");
            Property(x => x.Header).HasColumnName("Header").IsOptional();
            Property(x => x.Content).HasColumnName("Content").IsOptional();

            HasRequired(x => x.AppUser).WithMany(x => x.Articles).HasForeignKey(x => x.AppUserID).WillCascadeOnDelete(false);
            HasRequired(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryID).WillCascadeOnDelete(false);
            HasMany(x => x.Likes).WithRequired(x => x.Article).HasForeignKey(x => x.ArticleID).WillCascadeOnDelete(false);
            HasMany(x => x.Comments).WithRequired(x => x.Article).HasForeignKey(x => x.ArticleID).WillCascadeOnDelete(false);
            


        }
    }
}
