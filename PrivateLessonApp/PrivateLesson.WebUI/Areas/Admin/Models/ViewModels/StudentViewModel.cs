using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;

namespace PrivateLesson.WebUI.Areas.Admin.Models.ViewModels
{
    public class StudentViewModel
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
        public string UserId { get; set; }
        public User User { get; set; }
        public List<TeacherViewModel> Teachers { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
