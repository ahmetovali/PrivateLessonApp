﻿using PrivateLesson.Entity.Abstract;
using PrivateLesson.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete
{
    public class Teacher :IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string? Url { get; set; }
        public string Graduation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }
        public List<TeacherBranch> TeacherBranches { get; set; }
        //public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
