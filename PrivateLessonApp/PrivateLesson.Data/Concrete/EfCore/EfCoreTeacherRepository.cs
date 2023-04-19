using Microsoft.EntityFrameworkCore;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Data.Concrete.EfCore.Context;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }

        public async Task CreateTeacher(Teacher teacher, int[] SelectedBranches)
        {
           await AppContext.Teachers.AddAsync(teacher);
            await AppContext.SaveChangesAsync();
            List<TeacherBranch> teacherBranches = new List<TeacherBranch>();
            foreach (var branchId in SelectedBranches)
            {
                teacherBranches.Add(new TeacherBranch
                {
                    BranchId= branchId,
                    TeacherId= teacher.Id
                });
            }
            AppContext.TeacherBranches.AddRange(teacherBranches);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string branchurl = null)
        {
            var teachers = AppContext
                 .Teachers
                 .Where(t => t.IsApproved == ApprovedStatus)
                 .Include(u => u.User)
                 .Include(i => i.Image)
                 .Include(t => t.TeacherBranches)
                 .ThenInclude(tb => tb.Branch)
                 .AsQueryable();
            if (branchurl != null)
            {
                teachers = teachers
                    .Where(t => t.TeacherBranches.Any(tb => tb.Branch.Url == branchurl));
            }
            return await teachers
                .Include(t=>t.TeacherStudents)
                .ThenInclude(ts=>ts.Student)
                .ToListAsync();
        }
    }
}
