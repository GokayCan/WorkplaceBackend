﻿using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class RegisterAuthDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public IFormFile Image { get; set; }
    }
}
