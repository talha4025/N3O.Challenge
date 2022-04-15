using MediatR;
using N3O.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace N3O.Challenge.Domain.Commands
{
    public class UpdateUserCommand:IRequest
    {
        public Guid id { get; }
        public User user { get; }
        public UpdateUserCommand(Guid _id, User _user)
        {
            id = _id;
            user = _user;
        }
    }
}
