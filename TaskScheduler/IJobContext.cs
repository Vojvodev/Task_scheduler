﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public interface IJobContext
    {
        public void CheckForPause();
        public bool CheckForStop();
    }
}
