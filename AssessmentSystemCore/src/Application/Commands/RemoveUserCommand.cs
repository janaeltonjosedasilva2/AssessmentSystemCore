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
    public class RemoveUserCommand : Command<RemoveUserRequest, RemoveUserResponse>
    {
        public RemoveUserCommand(IWriteRepository repository) : base(repository)
        {
        }

        protected override RemoveUserResponse Changes(RemoveUserRequest request)
        {
            _repository.Remove<User>(request.Id);

            return new RemoveUserResponse();
        }
    }
}
