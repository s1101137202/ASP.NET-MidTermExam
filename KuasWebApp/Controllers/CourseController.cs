using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course Course)
        {
            CheckCourseIsNotNullThrowException(Course);

            try
            {
                CourseService.AddEmployee(Course);
                return CourseService.GetCourseByName(Course.CourseName);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Course UpdateCourse(Course Course)
        {
            CheckCourseIsNullThrowException(Course);

            try
            {
                CourseService.UpdateEmployee(Course);
                return CourseService.GetCourseByName(Course.CourseName);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteCourse(Course Course)
        {
            try
            {
                CourseService.DeleteCourse(Course);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Course> GetAllCourse()
        {
            return CourseService.GetAllCourse();
        }

        [HttpGet]
        [ActionName("byName")]
        public Course GetCourseByName(string CourseName)
        {
            var Course = CourseService.GetCourseByName(CourseName);

            if (Course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Course;
        }


        private void CheckCourseIsNullThrowException(Course Course)
        {
            Course dbCourse = CourseService.GetCourseByName(Course.CourseName);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }


        private void CheckEmployeeIsNotNullThrowException(Course Course)
        {
            Course dbEmployee = CourseService.GetCourseByName(Course.CourseName);

            if (dbEmployee != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
