namespace ElevenNote.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNetCore.Identity;
    using OfficeDevPnP.Core.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ElevenNote.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ElevenNote.Data.ApplicationDbContext";
        }

        protected override void Seed(ElevenNote.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            const string userId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            string email = "Test@test.com";
            string password = "Test1!";
            var hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser user = new ApplicationUser
            {
                Email = email,
                EmailConfirmed = true,
                Id = userId,
                UserName = email,
                PhoneNumberConfirmed = false,
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(null, password);
            context.Users.AddOrUpdate(user);

            Note note1 = new Note()
            {
                NoteId=1,
                OwnerId= Guid.Parse(userId),
                Title="Seeded Note",
                Content="This note is seeded",
                CreatedUtc=System.DateTimeOffset.Now,
            };
            context.Notes.AddOrUpdate(note1);

            context.SaveChanges();
        }
    }
}
