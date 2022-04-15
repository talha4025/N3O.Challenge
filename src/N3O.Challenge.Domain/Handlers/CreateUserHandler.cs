using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Commands;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand,bool>
    {
        
        private readonly ISimpleCache<Guid, User> _cache;
        public CreateUserHandler(ISimpleCache<Guid, User> cache)
        {
            _cache = cache;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var age = DateTime.Today.Year - request.user.DateOfBirth.Year;
            if (age > 18)
            {
                return false;
            }

            var users=await _cache.GetAllAsync();
            if (users.Where(c => c.Email == request.user.Email).FirstOrDefault()!=null)
            {
                return false;
            }

            await _cache.AddAsync(request.id, request.user);
            return true;
        }

        
    }
}
