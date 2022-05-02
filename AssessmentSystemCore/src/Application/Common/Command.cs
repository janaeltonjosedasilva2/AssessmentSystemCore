using AssessmentSystemCore.Domain.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Common
{
    public abstract class Command <TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        protected IWriteRepository _repository;

        protected Command(IWriteRepository repository)
        {
            _repository = repository;
        }
        protected abstract TResponse Changes(TRequest request);
        public virtual TResponse Handle(TRequest request)
        {
            var response = Changes(request);

            _repository.Commit();

            return response;
        }
    }
}
