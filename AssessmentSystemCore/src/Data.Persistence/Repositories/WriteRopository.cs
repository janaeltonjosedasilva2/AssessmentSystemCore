using AssessmentSystemCore.Data.Persistence.Contexts;
using AssessmentSystemCore.Domain.Shared.Entities;
using AssessmentSystemCore.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Data.Persistence.Repositories
{
    public class WriteRopository : IWriteRepository
    {
        private AssessmentSystemCoreContext _context;

        public WriteRopository(AssessmentSystemCoreContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> AsQueryble<TEntity>() where TEntity : Entity
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Remove<TEntity>(Guid id) where TEntity : Entity
        {
            var table = _context.Set<TEntity>();
            
            var entity = table.Find(id);

            if (entity != null)
            {
                table.Remove(entity);
            }
        }
    }
}
