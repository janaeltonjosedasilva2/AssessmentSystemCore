using AssessmentSystemCore.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Requests
{
    public class UpdateUserRequest : Request
    {
        public string Name { get; set; }
        public string Email { get; set; }

        private Guid id;

        public Guid GetId()
        {
            return id;
        }

        public void SetId(Guid value)
        {
            id = value;
        }
    }
}
