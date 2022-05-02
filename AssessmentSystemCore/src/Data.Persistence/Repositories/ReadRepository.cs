using AssessmentSystemCore.Data.Persistence.Contexts;
using AssessmentSystemCore.Domain.Shared.Entities;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AssessmentSystemCore.Data.Persistence.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private AssessmentSystemCoreContext _context;

        public ReadRepository(AssessmentSystemCoreContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> AsQueryble<TEntity>() where TEntity : Entity
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
    }
}
