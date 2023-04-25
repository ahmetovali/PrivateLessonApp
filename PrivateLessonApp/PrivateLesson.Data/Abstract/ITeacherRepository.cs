using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool ApprovedStatus, string branchurl = null);
        Task CreateTeacher(Teacher teacher, int[] SelectedBranches);
        Task<Teacher> GetTeacherFullDataAsync(int id);
        Task UpdateTeacher(Teacher teacher, int[] SelectedBranches);
    }
}
