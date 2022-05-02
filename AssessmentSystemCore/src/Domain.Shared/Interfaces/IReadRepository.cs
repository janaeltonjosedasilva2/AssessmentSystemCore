using AssessmentSystemCore.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Domain.Shared.Interfaces
{
    public interface IReadRepository
    {
        IQueryable<TEntity> AsQueryble<TEntity>() where TEntity : Entity;
    }
}
