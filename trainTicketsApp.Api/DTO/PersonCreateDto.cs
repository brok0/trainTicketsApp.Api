﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainTicketsApp.Api.DTO
{
    public class PersonCreateDto
    {
       
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
