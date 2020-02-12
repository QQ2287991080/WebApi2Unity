using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnityProject.IServices;

namespace UnityProject.Controllers
{
    public class TestController : ApiController
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        public TestController(IStudentService studentService)
        {
            _studentService = studentService;
            //_teacherService = teacherService;,ITeacherService teacherService
        }
        [HttpPost]
        public string GetName()
        {
            return _studentService.GetTypeName();
        }
    }
}
