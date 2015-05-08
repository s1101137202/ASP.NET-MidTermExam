using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CourseService : IEmployeeService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddCourse(Course Course)
        {
            CourseDao.AddCourse(Course);
        }

        public void UpdateCourse(Course Course)
        {
            CourseDao.UpdateCourse(Course);
        }

        public void DeleteCourse(Course Course)
        {
            Course = CourseDao.GetCourseByName(Course.CourseName);

            if (Course != null)
            {
                CourseDao.DeleteCourse(Course);
            }
        }

        public IList<Course> GetAllCourses()
        {
            return CourseDao.GetAllCourses();
        }

        public Course GetCourseByName(string id)
        {
            return CourseDao.GetCourseByName(CourseName);
        }

    }

}
