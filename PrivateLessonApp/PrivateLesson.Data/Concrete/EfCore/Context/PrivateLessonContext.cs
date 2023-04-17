using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivateLesson.Data.Concrete.EfCore.Config;
using PrivateLesson.Data.Concrete.EfCore.Extensions;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore.Context
{
    public class PrivateLessonContext : IdentityDbContext<User, Role, string >
    {
        public PrivateLessonContext(DbContextOptions options) : base (options) { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TeacherBranch> TeacherBranches { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.SeedData();
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly);
            base.OnModelCreating(modelbuilder);
        }



    }
}
