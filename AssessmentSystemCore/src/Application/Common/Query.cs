using AssessmentSystemCore.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Common
{
    public abstract class Query<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        protected IReadRepository _repository;

        protected Query(IReadRepository repository)
        {
            _repository = repository;
        }

        public abstract TResponse Handle(TRequest request);
    }
}
