﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Main
{
    [Serializable]
    public class ChangeUserInfoResponse
    {
        public bool Success { get; set; }


        public string Message { get; set; }
    }
}
