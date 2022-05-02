using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Domain.Shared.Entities
{
    public abstract class Entity
    {
        //For EF to be able to instantiate an entity using reflaction.
        protected Entity(){}

        public Entity(Guid guid)
        {
            Id = guid;
            var dateTime = DateTime.Now;
            RegisteDate = dateTime;
            LastUpdate = dateTime;
            IsActive = true;
        }

        public Guid Id { get; private set; }
        public DateTime RegisteDate { get; private set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
    }
}
