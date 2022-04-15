using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Commands;
using N3O.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly ISimpleCache<Guid, User> _cache;
        public UpdateUserHandler(ISimpleCache<Guid, User> cache)
        {
            _cache = cache;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _cache.UpdateAsync(request.id, request.user);
            return Unit.Value;
        }
    }
}
