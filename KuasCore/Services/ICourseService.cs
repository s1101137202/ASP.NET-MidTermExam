using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{

    public interface IEmployeeService
    {

      
        void AddCourse(Course Course);
        void UpdateCourse(Course Course);
        void DeleteCourse(Course Course);
        IList<Course> GetAllCourses();
        Employee GetCourseByName(string CourseName);

    }
}
