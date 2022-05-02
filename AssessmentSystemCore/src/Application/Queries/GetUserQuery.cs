using AssessmentSystemCore.Application.Common;
using AssessmentSystemCore.Application.Requests;
using AssessmentSystemCore.Application.Responses;
using AssessmentSystemCore.Data.Persistence.Extensions;
using AssessmentSystemCore.Domain.Core.Entities;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace AssessmentSystemCore.Application.Queries
{
    public class GetUserQuery : Query<GetUserRequest, GetUserResponse>
    {
        public GetUserQuery(IReadRepository repository) : base(repository)
        {
        }

        public override GetUserResponse Handle(GetUserRequest request)
        {
            var predicate = PredicateBuilder.New<User>();

            if (request.Name != null) predicate = predicate.And(x => x.Name.Contains(request.Name));

            if (request.Email != null) predicate = predicate.And(x => x.Email.Contains(request.Email));

            var result = _repository
                .AsQueryble<User>()
                .Where(predicate)
                .Select(x => new GetUserResponseItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    RegisteDate = x.RegisteDate
                });

            return new GetUserResponse { Data = result };
        }
    }
}
