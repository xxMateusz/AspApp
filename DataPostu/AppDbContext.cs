using DataPostu.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPostu
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PostEntity> Pots { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "bazaPost.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
     options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja Identity
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string ROLE_ID_ADMIN = Guid.NewGuid().ToString();
            string ROLE_ID_USER = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID_ADMIN,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = ROLE_ID_USER,
                    Name = "user",
                    NormalizedName = "USER"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            var adminUser = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "adminPass123")
            };

            var regularUser = new IdentityUser
            {
                Id = USER_ID,
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "userPass123")
            };

            modelBuilder.Entity<IdentityUser>().HasData(adminUser, regularUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_ADMIN,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID_USER,
                    UserId = USER_ID
                }
            );



            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity
                {
                    Id = 1,
                    Content = "Pierwszy post na blogu",
                    Author = "Jan Kowalski",
                    PublicationDate = new DateTime(2021, 1, 1),
                    Tags = "pierwszy, blog",
                    Comment = "To jest pierwszy post na moim blogu!",
                    Created = DateTime.Now
                },
                new PostEntity
                {
                    Id = 2,
                    Content = "Drugie post",
                    Author = "Anna Nowak",
                    PublicationDate = new DateTime(2021, 1, 2),
                    Tags = "wprowadzenie, blog",
                    Comment = "Drugi post na blogu z moimi przemyśleniami.",
                    Created = DateTime.Now
                }
            );
        }
    }
}
