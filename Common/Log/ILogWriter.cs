﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Log
{
    public interface ILogWriter
    {
        void WriteLog(String ex);
    }
}
