using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    public interface IBranchService
    {
        Task CreateAsync(Branch branch);
        Task<List<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        void Update(Branch branch);
        void Delete(Branch branch);
        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);
        Task<string> GetBranchNameByUrlAsync(string url);
        Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus);

        Task<Branch> GetBranchFullDataAsync(int id);
        Task<List<Branch>> GetBranchesByTeacherAsync(int id);
    }
}
