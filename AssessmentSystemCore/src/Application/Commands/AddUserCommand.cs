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
    public class AddUserCommand : Command<AddUserRequest, AddUserResponse>
    {
        public AddUserCommand(IWriteRepository repository) : base(repository)
        {
        }

        protected override AddUserResponse Changes(AddUserRequest request)
        {
            var user = new User(request.Name, request.Email);

            _repository.Add(user);

            return new AddUserResponse()
            {
                Id = user.Id,
                RegisteDate = user.RegisteDate
            };
        }
    }
}
