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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly ISimpleCache<Guid, User> _cache;
        public DeleteUserHandler(ISimpleCache<Guid, User> cache)
        {
            _cache = cache;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _cache.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}
