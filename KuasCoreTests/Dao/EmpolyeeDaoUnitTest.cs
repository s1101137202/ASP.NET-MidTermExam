using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{

    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region 單元測試 Spring 必寫的內容 
        
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseDao CourseDao { get; set; }


        [TestMethod]
        public void TestCourseDao_AddCourse()
        {
            Course Course = new Course();
            Course.CourseId = "UnitTests";
            Course.CourseName = "單元測試";
            Course.CourseDescription = "testtttt";
            CourseDao.AddCourse(Course);

            Course dbCourse = CourseDao.GetCourseByName(Course.CourseName);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseId, dbCourse.CourseId);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByName(Course.CourseName);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_UpdateCourse()
        {
            // 取得資料
            Course Course = CourseDao.GetCourseByName("JAVA");
            Assert.IsNotNull(Course);
            
            // 更新資料
            Course.CourseName = "單元測試";
            CourseDao.UpdateCourse(Course);

            // 再次取得資料
            Course dbCourse = CourseDao.GetCourseByName(Course.CourseId);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            Course.CourseName = "JAVA";
            CourseDao.UpdateCourse(Course);

            // 再次取得資料
            dbCourse = CourseDao.GetCourseByName(Course.CourseId);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(Course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);


        [TestMethod]
        public void TestEmployeeDao_DeleteEmployee()
        {
            Course newEmployee = new Course();
            newCourse.CourseId = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "testtttt";
            CourseDao.AddCourse(newCourse);

            Course dbCourse = CourseDao.GetCourseByName(newCourse.CourseName);
            Assert.IsNotNull(dbCourse);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseByName(newCourse.CourseName);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestEmployeeDao_GetEmployeeById()
        {
            Course employee = CourseDao.GetCourseByName("JAVA");
            Assert.IsNotNull(employee);
            Console.WriteLine("課程編號為 = " + dbCourse.CourseId);
            Console.WriteLine("課程姓名為 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述為 = " + dbCourse.CourseDescription);
        }

    }
}
