using FoodTable.Core.Map;
using FoodTable.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTable.Map.Option
{
    public class LikeMap:CoreMap<Like>
    {
        public LikeMap()
        {
            ToTable("Likes");
            Property(x => x.LikeNumber).IsOptional();
            HasKey(x => new { x.AppUserID, x.ArticleID });
        }
    }
}
