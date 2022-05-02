using AssessmentSystemCore.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Responses
{
    public class AddUserResponse : Response
    {
        public Guid Id { get; set; }
        public DateTime RegisteDate { get; set; }
    }
}
