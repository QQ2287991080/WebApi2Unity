﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityProject.IServices
{
  public  interface ITeacherService: ISuperService
    {
        string GetTypeName();
    }
}