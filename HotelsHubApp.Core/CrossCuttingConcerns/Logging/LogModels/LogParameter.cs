﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Core.CrossCuttingConcerns.Logging.LogModels
{
    public class LogParameter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
