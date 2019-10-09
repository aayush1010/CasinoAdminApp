namespace Casino.AdminPortal.Shared.Infrastructure.Common.Validation
{
    public class EmployeePortalValidationFailure
    {
        public object AttemptedValue { get; }
        public object CustomState { get; set; }
        public string ErrorMessage { get; }
        public string PropertyName { get; set; }

        public EmployeePortalValidationFailure(string propertyName, string error)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
        }

        public EmployeePortalValidationFailure(string propertyName, string error, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
            AttemptedValue = attemptedValue;
        }
    }
}
