using System;
using System.Collections.Generic;
using System.Text;

namespace GovUkDesignSystem.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
    public class GovUkAdditionalMetadataValueAttribute : Attribute
    {
        public GovUkAdditionalMetadataValueAttribute(object key, object value)
        {
            Key = key;
            Value = value;
        }
        public object Key { get; set; }
        public object Value { get; set; }
    }
}
