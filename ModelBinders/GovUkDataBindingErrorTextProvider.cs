﻿using GovUkDesignSystem.Attributes.DataBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Linq;

namespace GovUkDesignSystem.ModelBinders
{
    /// <summary>
    /// This class ensures that any attributes required by the GovUk custom model binders are available in the binding
    /// context's ValidatorMetadata property.
    /// </summary>
    public class GovUkDataBindingErrorTextProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.Attributes.OfType<GovUkDataBindingErrorTextAttribute>())
            {
                context.ValidationMetadata.ValidatorMetadata.Add(attribute);
            }
        }
    }
}
