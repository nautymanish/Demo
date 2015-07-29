using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    // public class Context: DbContext 
    //{
    //     public DbSet<Answer> Answers { get; set; }
    //     public DbSet<Question> Questions { get; set; }
    //     public DbSet<AspNetUsers> Users { get; set; }
    //     public Context()
    //         : base()
    //     {

    //     }
         
    //}

    public partial class Context : DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Text)
                .IsUnicode(false);
        }
    }
    
}