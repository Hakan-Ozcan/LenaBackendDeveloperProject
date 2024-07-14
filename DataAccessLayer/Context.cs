using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<FormSubmissionField> FormSubmissionFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SAWRNTGOYZLM6\\SQLEXPRESS;Database=LenaAppDb;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
              .HasOne(f => f.CreatedByUser)
              .WithMany(u => u.CreatedForms)
              .HasForeignKey(f => f.CreatedBy);

            modelBuilder.Entity<FormField>()
                .HasOne(ff => ff.Form)
                .WithMany(f => f.Fields)
                .HasForeignKey(ff => ff.FormId);

            modelBuilder.Entity<FormSubmission>()
                .HasOne(fs => fs.Form)
                .WithMany(f => f.Submissions)
                .HasForeignKey(fs => fs.FormId);

            modelBuilder.Entity<FormSubmission>()
                .HasOne(fs => fs.User)
                .WithMany(u => u.FormSubmissions)
                .HasForeignKey(fs => fs.UserId);

            modelBuilder.Entity<FormSubmissionField>()
                .HasOne(fsf => fsf.FormSubmission)
                .WithMany(fs => fs.Fields)
                .HasForeignKey(fsf => fsf.FormSubmissionId);

            modelBuilder.Entity<FormSubmissionField>()
                .HasOne(fsf => fsf.FormField)
                .WithMany(ff => ff.FormSubmissionFields)
                .HasForeignKey(fsf => fsf.FormFieldId);
        }
    }
}
