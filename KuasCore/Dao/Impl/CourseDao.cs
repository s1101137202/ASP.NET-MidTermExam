
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {

        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course Course)
        {
            string command = @"INSERT INTO Course (CourseId, CourseName, CourseDescription) VALUES (@CourseId, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.CourseId;
            parameters.Add("CourseName", DbType.String).Value = Course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = Course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course Course)
        {
            string command = @"UPDATE Course SET CourseName = @CourseName, CourseDescription = @CourseDescription WHERE CourseId = @CourseId;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.CourseId;
            parameters.Add("CourseName", DbType.String).Value = Course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = Course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course Course)
        {
            string command = @"DELETE FROM Course WHERE CourseId = @CourseId";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Course.Id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY Id ASC";
            IList<Course> Course = ExecuteQueryWithRowMapper(command);
            return Course;
        }

        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Employee WHERE CourseId = @CourseId";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseId", DbType.String).Value = Courseid;

            IList<Course> employees = ExecuteQueryWithRowMapper(command, parameters);
            if (employees.Count > 0)
            {
                return Course[0];
            }

            return null;
        }

    }
}
