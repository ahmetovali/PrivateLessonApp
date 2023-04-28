using Microsoft.AspNetCore.Mvc;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BranchesController : Controller
    {
        private IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IActionResult> Index(BranchListViewModel branchListViewModel)
        {
            List<Branch> branchList = await _branchService.GetAllBranchesFullDataAsync(branchListViewModel.ApprovedStatus);
            List<BranchViewModel> branches = new List<BranchViewModel>();
            foreach (var branch in branchList)
            {
                branches.Add(new BranchViewModel
                {
                    Id = branch.Id,
                    BranchName = branch.BranchName,
                    Description = branch.Description,
                    CreatedDate = branch.CreatedDate,
                    UpdatedDate = branch.UpdatedDate,
                    IsApproved = branch.IsApproved,
                    Url = branch.Url,
                    Teachers= branch.TeacherBranches.Select(tb => new TeacherViewModel
                    {
                        Id = tb.Teacher.Id,
                        User = tb.Teacher.User,
                        FirstName = tb.Teacher.User.FirstName,
                        LastName = tb.Teacher.User.LastName,
                        Url = tb.Teacher.Url
                    }).ToList()
                });
            }
            branchListViewModel.Branches = branches;

            return View(branchListViewModel);
        }
    }
}
