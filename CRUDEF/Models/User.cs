﻿using System;
using System.Collections.Generic;

namespace CRUDEF.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
