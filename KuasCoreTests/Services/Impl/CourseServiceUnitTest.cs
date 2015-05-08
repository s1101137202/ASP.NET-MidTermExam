using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class EmployeeServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course empolyee = new Course();
            newCourse.CourseId = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "testtttt";
            CourseService.AddEmployee(Course);

            Course dbEmpolyee = CourseService.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseId, dbCourse.CourseId);


            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseByName(Course.CourseName);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
             Course = CourseService.GetCourseByName("JAVA");
            Assert.IsNotNull(Course);

            // 更新資料
            Course.CourseName = "單元測試";
            CourseService.UpdateCourse(Course);

            // 再次取得資料
            Course dbCourse = CourseService.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            Course.CourseName = "JAVA";
            CourseService.UpdateCourse(Course);

            // 再次取得資料
            dbCourse = CourseService.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);
        }


        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.CourseId = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "testtttt";
            CourseService.AddCourse(newCourse);

            Course dbCourse = CourseService.GetCourseByName(newCourse.CourseName);
            Assert.IsNotNull(dbCourse);

            CourseService.DeleteCourse(dbCourse);
            dbEmpolyee = EmployeeService.GetCourseByName(newCourse.CourseName);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_GetCourseById()
        {
            Course Course = CourseService.GetCourseByName("JAVA");
            Assert.IsNotNull(Course);
            
            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);
        }

    }
}
