using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Linq;

//qq:DCC move somewhere more appropriate
namespace GovUkDesignSystem.Attributes
{
    public class GovUkValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.Attributes.OfType<GovUkDisplayNameForErrorsAttribute>())
            {
                context.ValidationMetadata.ValidatorMetadata.Add(attribute);
            }
        }
    }
}
