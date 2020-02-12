using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityProject.Controllers;
using UnityProject.Services;

namespace UnityProject.Tests.Controllers
{
    [TestClass]
    public class TestControllerTest
    {
        [TestMethod]
        public void GetName()
        {
            Debug.WriteLine(DateTime.Now);
            StudentService studentService = new StudentService();
            TeacherService teacherService = new TeacherService();
            // 排列
            TestController controller = new TestController(studentService, teacherService);

            // 操作
            string name = controller.GetName();
            Console.WriteLine(name);
            // 断言
            Assert.IsNotNull(name);
            //Assert.AreEqual(2, result.Count());
        }
    }
}
