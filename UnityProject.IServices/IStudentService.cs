using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityProject.IServices
{
   public interface IStudentService: ISuperService
    {
        string GetTypeName();

    }
}
