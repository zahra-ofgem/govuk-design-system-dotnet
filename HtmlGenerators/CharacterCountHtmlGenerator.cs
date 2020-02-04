﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem.HtmlGenerators
{
    internal static class CharacterCountHtmlGenerator
    {
        internal static IHtmlContent GenerateHtmlDcc<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null
        )
            where TModel : class
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyExpression);
            ThrowIfPropertyDoesNotHaveCharacterCountAttribute(property);
            int maximumCharacters = GetMaximumCharacters(property);

            string propertyId = htmlHelper.IdFor(propertyExpression);
            string propertyName = htmlHelper.NameFor(propertyExpression);
            htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var modelStateEntry);

            // Get the value to put in the input from the post data if possible, otherwise use the value in the model
            string inputValue = null;
            if (modelStateEntry != null && modelStateEntry.RawValue != null)
            {
                inputValue = modelStateEntry.RawValue as string;
            }
            else
            {
                var modelValue = ExpressionHelpers.GetPropertyValueFromModelAndExpression(htmlHelper.ViewData.Model, propertyExpression);
                if (modelValue != null)
                {
                    inputValue = modelValue.ToString();
                }
            }

            var characterCountViewModel = new CharacterCountViewModel
            {
                Name = propertyName,
                Id = propertyId,
                MaxLength = maximumCharacters,
                Value = inputValue,
                Rows = rows,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions
            };

            if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
            {
                // qq:DCC Are we OK with only displaying the first error message here?
                characterCountViewModel.ErrorMessage = new ErrorMessageViewModel { Text = modelStateEntry.Errors[0].ErrorMessage };
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/CharacterCount.cshtml", characterCountViewModel);
        }

        internal static IHtmlContent GenerateHtml<TModel>(
            IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null
        )
            where TModel : GovUkViewModel
        {
            PropertyInfo property = ExpressionHelpers.GetPropertyFromExpression(propertyLambdaExpression);
            ThrowIfPropertyDoesNotHaveCharacterCountAttribute(property);

            string propertyName = property.Name;

            TModel model = htmlHelper.ViewData.Model;

            string currentValue = ExtensionHelpers.GetCurrentValue(model, property, propertyLambdaExpression);

            int maximumCharacters = GetMaximumCharacters(property);

            var characterCountViewModel = new CharacterCountViewModel {
                Name = $"GovUk_Text_{propertyName}",
                Id = $"GovUk_{propertyName}",
                MaxLength = maximumCharacters,
                Value = currentValue,
                Rows = rows,
                Label = labelOptions,
                Hint = hintOptions,
                FormGroup = formGroupOptions
            };

            if (model.HasErrorFor(property))
            {
                characterCountViewModel.ErrorMessage = new ErrorMessageViewModel {Text = model.GetErrorFor(property)};
            }

            return htmlHelper.Partial("/GovUkDesignSystemComponents/CharacterCount.cshtml", characterCountViewModel);
        }

        private static void ThrowIfPropertyDoesNotHaveCharacterCountAttribute(PropertyInfo property)
        {
            var attribute = property.GetSingleCustomAttribute<GovUkValidateCharacterCountAttribute>();

            if (attribute == null)
            {
                throw new ArgumentException(
                    "GovUkCharacterCountFor can only be used on properties that are decorated with a GovUkValidateCharacterCount attribute. "
                    + $"Property [{property.Name}] on type [{property.DeclaringType.FullName}] does not have this attribute");
            }
        }

        private static int GetMaximumCharacters(PropertyInfo property)
        {
            var attribute = property.GetSingleCustomAttribute<GovUkValidateCharacterCountAttribute>();
            return attribute.MaxCharacters;
        }

    }
}
