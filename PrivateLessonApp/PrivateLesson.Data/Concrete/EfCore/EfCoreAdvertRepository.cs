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
    public class EfCoreAdvertRepository : EfCoreGenericRepository<Advert>, IAdvertRepository
    {
        public EfCoreAdvertRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }


        public Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            var adverts = AppContext
                 .Adverts
                 .Where(t => t.IsApproved == approvedStatus)
                 .Include(a => a.Teacher)
                 .ThenInclude(u => u.User)
                 .ThenInclude(i => i.Image)
                 .Include(a => a.Teacher)
                 .ThenInclude(t => t.TeacherBranches)
                 .ThenInclude(tb => tb.Branch)
                 .AsQueryable();
            if (id != null)
            {
                adverts = adverts.Where(a => a.Teacher.User.Id == id);
            }
            return adverts.ToListAsync();
        }

        public Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus)
        {
            var adverts = AppContext
                        .Adverts
                        .Where(a => a.IsApproved == approvedStatus)
                        .Include(a => a.Teacher)
                        .ThenInclude(u => u.User)
                        .ThenInclude(i => i.Image)
                        .Include(a => a.Teacher)
                        .ThenInclude(t => t.TeacherBranches)
                        .ThenInclude(tb => tb.Branch)
                        .ToListAsync();
            return adverts;
        }
    }
}
