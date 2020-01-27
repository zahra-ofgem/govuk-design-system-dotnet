using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes;

namespace GovUkDesignSystem.ModelBinders
{
    public class GovUkMandatoryIntBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var names = bindingContext.ModelMetadata.ValidatorMetadata.OfType<GovUkDisplayNameForErrorsAttribute>().SingleOrDefault();
            if (names == null)
            {
                throw new System.Exception("When using the GovUkMandatoryIntBinder you must also provide a GovUkDisplayNameForErrors attribute and ensure that you register GovUkValidationMetadataProvider in your applications Startup.ConfigureServices method.");
            }
            var nameWithinSentence = names.NameWithinSentence;
            var nameAtStartOfSentence = names.NameAtStartOfSentence;

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"Enter {nameWithinSentence}");
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"Enter {nameWithinSentence}");
                return Task.CompletedTask;
            }

            if (!double.TryParse(value, out var doubleValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a number");
                return Task.CompletedTask;
            }

            if (!int.TryParse(value, out var intValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{nameAtStartOfSentence} must be a whole number");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(intValue);
            return Task.CompletedTask;
        }
    }
}
