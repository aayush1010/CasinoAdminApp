using System.Collections.Generic;

namespace Casino.AdminPortal.Shared.Infrastructure.Common.Validation
{
    public class EmployeePortalValidationResult
    {
        public IList<EmployeePortalValidationFailure> Errors { get; }

        public bool IsValid => Errors == null || Errors.Count == 0;

        public EmployeePortalValidationResult(IList<EmployeePortalValidationFailure> failures)
        {
            Errors = failures;
        }

        public EmployeePortalValidationResult()
        {
            Errors = new List<EmployeePortalValidationFailure>();
        }
    }
}
