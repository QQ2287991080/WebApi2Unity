using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityProject.IServices;

namespace UnityProject.Services
{
    public class TeacherService: ITeacherService
    {
        public string GetTypeName()
        {
            return this.GetType().Name;
        }
    }
}
