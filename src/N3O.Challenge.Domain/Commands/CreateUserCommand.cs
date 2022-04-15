using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Commands
{
    public class CreateUserCommand: IRequest<bool>
    {
        public Guid id { get; }
        public User user { get; }
        public CreateUserCommand(Guid _id, User _user)
        {
            id = _id;
            user = _user;
        }
    }
}
