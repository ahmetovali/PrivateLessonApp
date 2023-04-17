﻿using PrivateLesson.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Entity.Concrete
{
    public class Image : IBaseEntity
    {
        public int Id { get; set ; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
    }
}
