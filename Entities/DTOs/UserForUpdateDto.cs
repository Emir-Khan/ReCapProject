﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
