using AssessmentSystemCore.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Domain.Core.Entities
{
    public class User : Entity
    {
        private User(){}
        public User(string name, string email) : base(Guid.NewGuid())
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
