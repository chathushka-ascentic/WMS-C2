using Ascentic.WorkFlow.EndSystems.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ascentic.WorkFlow.EndSystems.Common
{
    public class WorkFlowContext : DbContext
    {
        public WorkFlowContext() : base("name=WorkFlowContext")
        { }

        public DbSet<Task> Task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure primary key
            //modelBuilder.Entity<AppRole>().HasKey<int>(u => u.UserRoleId);
            //modelBuilder.Entity<AppRole>().Property(u => u.UserRoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<AppUser>().HasKey<int>(u => u.UserId);
            //modelBuilder.Entity<AppUser>().Property(u => u.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ////One to many relationship User role and User
            //modelBuilder.Entity<UserRole>()
            //            .HasMany<User>(u => u.Users)
            //            .WithRequired(a => a.UserRole)
            //            .HasForeignKey(p => p.UserRole.UserRoleId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
