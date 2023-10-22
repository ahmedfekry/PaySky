//using BulkyBook.Models.Models;
using Microsoft.EntityFrameworkCore;
using PaySky.Models.ApiModels.Role;
using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.ApiModels.UserVacancyEntity;
using PaySky.Models.ApiModels.VacancyEntity;


namespace PaySky.DataAccess
{
    public class PaySkyDBContext : DbContext
    {
        public PaySkyDBContext(DbContextOptions<PaySkyDBContext> options) : base(options) {
        
        }
        public DbSet<Vacancy> Vacancies { get; set; }   
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; } 

        public DbSet<UserVacancy> UserVacancies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy { Id=1,Title="First Vacancy", Description="Description", 
                    ExpiryDate=( DateTime.Now.AddDays(60)),CreatedDate=(DateTime.Now.AddDays(60)) }    
            );

            modelBuilder.Entity<UserRole>().HasData( 
                new UserRole { Id=1,Name="Applicant"}, 
                new UserRole { Id=2,Name= "Employer" }
            );

            modelBuilder.Entity<User>()
                .HasMany(v => v.vacancies)
                .WithMany(u => u.Applicants)
                .UsingEntity<UserVacancy>(
                    j => j.HasOne(uv => uv.Vacancy)
                    .WithMany(u => u.UserVacancies)
                    .HasForeignKey(uv => uv.VacanyId),
                    
                    j => j.HasOne(uv => uv.User)
                    .WithMany(u => u.UserVacancies)
                    .HasForeignKey(uv => uv.UserId),

                    j =>
                    {
                        j.Property(uv => uv.AddedOn).HasDefaultValueSql("GETDATE()");
                        j.HasKey(t => new { t.VacanyId, t.UserId });
                    }
                );

        }
    }

}
