using FoodTable.Core.Map;
using FoodTable.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTable.Map.Option
{
    public class CommentMap:CoreMap<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");
            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.CommentNumber).HasColumnName("CommentNumber").IsOptional();

            HasKey(x => new { x.AppUserID, x.ArticleID });


        }
    }
}
