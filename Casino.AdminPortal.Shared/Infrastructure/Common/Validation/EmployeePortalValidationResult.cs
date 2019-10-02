using System.Collections.Generic;

namespace Casino.AdminPortal.Shared
{
    public class EmployeePortalValidationResult
    {
        public IList<EmployeePortalValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

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
