﻿using System;

namespace WorldCulture.Api.Dtos
{
    public class AccountForRegisterDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}