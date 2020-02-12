using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace UnityProject.Models
{
    public class UnityModel
    {
        [InjectionMethod]
        public void GetName()
        {


        }
        [Dependency]
        public int MyProperty { get; set; }
    }
}