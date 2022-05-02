using AssessmentSystemCore.Application.Commands;
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
    public class GetUserByIdQuery : Query<GetUserByIdRequest, GetUserByIdResponse>
    {
        public GetUserByIdQuery(IReadRepository repository) : base(repository)
        {
        }

        public override GetUserByIdResponse Handle(GetUserByIdRequest request)
        {
            //var user = _repository.AsQueryble<User>().JoinByExpression(u => u.Login, u => u.PersonalData).SingleOrDefault(u => u.Id == request.Id); //Join with entity.

            //var user = _repository.AsQueryble<User>().JoinByString("User.Login", "User.PersonalData").SingleOrDefault(u => u.Id == request.Id); //Join with string

            var user = _repository.AsQueryble<User>().SingleOrDefault(u => u.Id == request.Id);

            var response = new GetUserByIdResponse();

            if (user == null)
            {
                response.AddError("User not found.");
                return response;
            }

            return new GetUserByIdResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                RegisteDate = user.RegisteDate,
                LastUpdate = user.LastUpdate,
                IsActive = user.IsActive
            };
        }
    }
}
