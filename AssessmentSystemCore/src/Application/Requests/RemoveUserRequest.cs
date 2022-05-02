using AssessmentSystemCore.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Requests
{
    public class RemoveUserRequest : Request
    {
        public Guid Id { get; set; }
    }
}
