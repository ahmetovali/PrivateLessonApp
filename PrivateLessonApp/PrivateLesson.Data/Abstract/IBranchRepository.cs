using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface IBranchRepository: IGenericRepository<Branch>
    {
        Task<string> GetBranchNameByUrlAsync(string url);
        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);
    }
}
