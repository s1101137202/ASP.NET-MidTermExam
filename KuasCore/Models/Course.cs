using System;

namespace KuasCore.Models
{
    public class Course
    {
        public string CourseID { get; set; }

        public string CourseName { get; set; }

        public Int32 CourseDescription { get; set; }

        public override string ToString()
        {
            return "Course: Id = " + CourseID + ", Name = " + CourseName + ".";
        }


        public string CourseId { get; set; }
    }
}
