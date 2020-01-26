using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GovUkDesignSystem.Attributes;

namespace GovUkDesignSystem.ModelBinders
{
    public class GovUkMandatoryIntBinder : IModelBinder
    {
        private readonly string _nameAtStartOfSentence;
        private readonly string _nameInSentence;

        public GovUkMandatoryIntBinder()
        {
            _nameAtStartOfSentence = "start";
            _nameInSentence = "in";
        }

        //public GovUkMandatoryIntBinder(string nameAtStartOfSentence, string nameInSentence)
        //{
        //    _nameAtStartOfSentence = nameAtStartOfSentence;
        //    _nameInSentence = nameInSentence;
        //}

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var defaultModelMetadata = bindingContext.ModelMetadata as DefaultModelMetadata; //qq:DCC this cast isn't great
            var names = defaultModelMetadata.Attributes.Attributes.FirstOrDefault(a => typeof(GovUkDisplayNameForErrorsAttribute).IsAssignableFrom(a.GetType())) as GovUkDisplayNameForErrorsAttribute;
            if (names == null)
            {
                throw new System.Exception("GovUkMandatoryIntBinder requires the property to also have a GovUkDisplayNameForErrors attribute");
            }

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"Enter {names.NameWithinSentence}");

                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"Enter {names.NameWithinSentence}");

                return Task.CompletedTask;
            }

            if (!double.TryParse(value, out var doubleValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{names.NameAtStartOfSentence} must be a number");
                return Task.CompletedTask;
            }

            if (!int.TryParse(value, out var intValue))
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"{names.NameAtStartOfSentence} must be a whole number");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(intValue);
            return Task.CompletedTask;
        }
    }
}
