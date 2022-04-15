using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.MappingProfiles;
using N3O.Challenge.Domain.Models;
using N3O.Challenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseModel>
    {
        private readonly ISimpleCache<Guid,User> _cache;
        public GetUserByIdHandler(ISimpleCache<Guid, User> cache)
        {
            _cache = cache;
        }

        public async Task<UserResponseModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user= await _cache.GetAsync(request.id);
            var userResponse = UserResponseMapping.MapToUserResponse(user);
            int age = DateTime.Today.Year - user.DateOfBirth.Year;
            userResponse.age = age;
            return userResponse;
        }
    }
}
