﻿namespace Prices.Web.Shared.Models.Users
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
    }
}