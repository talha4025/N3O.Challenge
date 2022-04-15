using MediatR;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace N3O.Challenge.Domain.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponseModel>
    {
        public Guid id { get; }
        public GetUserByIdQuery(Guid _id)
        {
            id = _id;
        }
    }
}
