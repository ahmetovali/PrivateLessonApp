using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.Entity.Concrete;

namespace PrivateLesson.WebUI.Areas.Admin.Models.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string Graduation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public List<BranchViewModel> Branches { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
