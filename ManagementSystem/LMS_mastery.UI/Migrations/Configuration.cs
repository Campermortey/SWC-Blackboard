using LMS_mastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LMS_mastery.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (roleMgr.RoleExists("Admin"))
                return;

            CreateRoles(roleMgr);
            CreateAdmin(mgr);
            CreateTeacher(mgr);
            CreateStudent(mgr);
            CreateGuardian(mgr);
        }

        private void CreateGuardian(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "parent",
                FirstName = "Mother",
                LastName = "Smith",
                SuggestedAccount = "Guardian"
            };

            mgr.Create(user, "testing123");
            mgr.AddToRole(user.Id, "Guardian");
        }

        private void CreateStudent(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "thing1",
                FirstName = "Thing1",
                LastName = "Smith",
                SuggestedAccount = "Student",
                GradeLevel = 1
            };

            mgr.Create(user, "testing123");
            mgr.AddToRole(user.Id, "Student");

            var user2 = new ApplicationUser()
            {
                UserName = "thing2",
                FirstName = "Thing2",
                LastName = "Smith",
                SuggestedAccount = "Student",
                GradeLevel = 2
            };

            mgr.Create(user2, "testing123");
            mgr.AddToRole(user2.Id, "Student");
        }

        private void CreateTeacher(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "teacher",
                FirstName = "Teacher",
                LastName = "Jones",
                SuggestedAccount = "Teacher"
            };

            mgr.Create(user, "testing123");
            mgr.AddToRole(user.Id, "Teacher");
        }

        private void CreateAdmin(UserManager<ApplicationUser> mgr)
        {
            var user = new ApplicationUser()
            {
                UserName = "admin",
                FirstName = "Admin",
                LastName = "God",
                SuggestedAccount = "Admin"
            };

            mgr.Create(user, "testing123");
            mgr.AddToRole(user.Id, "Admin");

        }

        private void CreateRoles(RoleManager<IdentityRole> roleMgr)
        {
            roleMgr.Create(new IdentityRole("Admin"));
            roleMgr.Create(new IdentityRole("Teacher"));
            roleMgr.Create(new IdentityRole("Guardian"));
            roleMgr.Create(new IdentityRole("Student"));
        }
    }
}
