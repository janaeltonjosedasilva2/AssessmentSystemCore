using AssessmentSystemCore.Application.Common;
using AssessmentSystemCore.Application.Requests;
using AssessmentSystemCore.Application.Responses;
using AssessmentSystemCore.Domain.Core.Entities;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Commands
{
    public class UpdateUserCommand : Command<UpdateUserRequest, UpdateUserResponse>
    {
        public UpdateUserCommand(IWriteRepository repository) : base(repository)
        {
        }

        protected override UpdateUserResponse Changes(UpdateUserRequest request)
        {
            var user = _repository.AsQueryble<User>().SingleOrDefault(u => u.Id == request.GetId());

            user.Name = request.Name;
            user.Email = request.Email;

            return new UpdateUserResponse();
        }
    }
}
