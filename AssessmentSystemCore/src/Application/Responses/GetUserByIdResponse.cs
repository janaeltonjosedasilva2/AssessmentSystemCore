using AssessmentSystemCore.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Responses
{
    public class GetUserByIdResponse : Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
