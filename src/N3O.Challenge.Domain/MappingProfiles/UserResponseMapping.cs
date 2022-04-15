using AutoMapper;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace N3O.Challenge.Domain.MappingProfiles
{
    public static class UserResponseMapping
    {
        

        public static UserResponseModel MapToUserResponse(User user)
        {
            UserResponseModel model = new UserResponseModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email, 
                DateOfBirth = user.DateOfBirth,
            };
            return model;
            
        }

    }
}
