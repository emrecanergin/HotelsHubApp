using FluentValidation;


namespace HotelsHubApp.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            //Creating ValidationContext
            var context = new ValidationContext<object>(entity);

            //validated via validator classes (based on each poco)
            var result = validator.Validate(context);
            if (!result.IsValid)
            { 
                throw new ValidationException(result.Errors);
            }
        }
    }
}
