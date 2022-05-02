using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentSystemCore.Application.Common
{
    public abstract class Response
    {
        private List<string> _errors { get; set; } = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();
        public bool IsSucess => !_errors.Any();

        public void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }
    }
}
