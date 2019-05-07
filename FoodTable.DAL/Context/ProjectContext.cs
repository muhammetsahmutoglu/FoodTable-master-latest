using FoodTable.Core.Entity;
using FoodTable.Map.Option;
using FoodTable.Model.Option;
using FoodTable.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FoodTable.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=302--10;Database=FoodTable;uid=sa;pwd=1234;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());           
            
            modelBuilder.Configurations.Add(new LikeMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Article> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }        
        public DbSet<Like> Likes { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string GetIp = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item.State == EntityState.Added)
                {
                    entity.CreatedUserName = identity;
                    entity.CreatedComputerName = computerName;
                    entity.CreatedDate = dateTime;
                    entity.CreatedIP = GetIp;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedUserName = identity;
                    entity.ModifiedComputerName = computerName;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedIP = GetIp;
                }
            }
            return base.SaveChanges();
        }
    }
}
