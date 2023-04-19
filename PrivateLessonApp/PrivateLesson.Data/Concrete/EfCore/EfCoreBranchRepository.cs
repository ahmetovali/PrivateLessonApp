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
    public class EfCoreBranchRepository : EfCoreGenericRepository<Branch>, IBranchRepository
    {
        public EfCoreBranchRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }

        public async Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus)
        {
            return await AppContext.Branches
                .Where(c=>c.IsApproved== ApprovedStatus)
                .ToListAsync();
        }

        public async Task<string> GetBranchNameByUrlAsync(string url)
        {
            Branch branch = await AppContext.Branches
                .Where(b=>b.Url== url)
                .FirstOrDefaultAsync();
            return branch.BranchName;
        }
    }
}
