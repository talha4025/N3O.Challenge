using AutoMapper;
using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.MappingProfiles;
using N3O.Challenge.Domain.Models;
using N3O.Challenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseModel>>
    {
        private readonly ISimpleCache<Guid,User> _cache;
       
        public GetAllUsersHandler(ISimpleCache<Guid, User> cache)
        {
            _cache = cache;
        }
        public async Task<IEnumerable<UserResponseModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _cache.GetAllAsync();
            
            List<UserResponseModel> response=new List<UserResponseModel>();
            foreach (var item in user)
            {
                var userResponse = UserResponseMapping.MapToUserResponse(item);
                int age = DateTime.Today.Year - item.DateOfBirth.Year;
                userResponse.age = age;
                response.Add(userResponse);
            }
            return response;
        }
    }
}
