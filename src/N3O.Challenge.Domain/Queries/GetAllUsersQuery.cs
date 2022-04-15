using MediatR;
using N3O.Challenge.Domain.Cache;
using N3O.Challenge.Domain.Entities;
using N3O.Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserResponseModel>>;
}
