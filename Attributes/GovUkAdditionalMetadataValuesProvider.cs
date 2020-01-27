using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//qq:DCC move somewhere more appropriate
namespace GovUkDesignSystem.Attributes
{
    public class GovUkAdditionalMetadataValuesProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            foreach (var attribute in context.Attributes.OfType<GovUkAdditionalMetadataValueAttribute>())
            {
                context.DisplayMetadata.AdditionalValues.Add(attribute.Key, attribute.Value);
            }
        }
    }
}
