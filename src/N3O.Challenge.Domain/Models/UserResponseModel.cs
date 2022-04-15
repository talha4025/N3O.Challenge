using System;
using System.Collections.Generic;
using System.Text;

namespace N3O.Challenge.Domain.Models
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int age { get; set; }
    }
}
