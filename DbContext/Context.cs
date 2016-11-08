using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DbContext.Models;

namespace DbContext
{
    public class Context : System.Data.Entity.DbContext
    {
        public Context() : base("Context")
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<AspNetRoles> AspNetRoleses { get; set; }
        public DbSet<AspNetUserClaims> AspNetUserClaimses { get; set; }
        public DbSet<AspNetUserLogins> AspNetUserLoginses { get; set; }
        public DbSet<AspNetUsers> AspNetUserses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}