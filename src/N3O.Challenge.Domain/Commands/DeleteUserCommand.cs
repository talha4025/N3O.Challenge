using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace N3O.Challenge.Domain.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public Guid id { get; }
        public DeleteUserCommand(Guid _id)
        {
            id = _id;
        }
    }
}
