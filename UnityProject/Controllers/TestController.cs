using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using UnityProject.IServices;
using UnityProject.Services;

namespace UnityProject.Controllers
{
    public class TestController : ApiController
    {
        
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        public TestController(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }
        [HttpPost]
        public string GetName()
        {
            return _studentService.GetTypeName();
        }
    }
}
