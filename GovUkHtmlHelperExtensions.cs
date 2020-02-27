using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using GovUkDesignSystem.HtmlGenerators;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GovUkDesignSystem
{
    public static class GovUkHtmlHelperExtensions
    {

        public static IHtmlContent GovUkAccordion(
            this IHtmlHelper htmlHelper,
            AccordionViewModel accordionViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Accordion.cshtml", accordionViewModel);
        }

        public static IHtmlContent GovUkBackLink(
            this IHtmlHelper htmlHelper,
            BackLinkViewModel backLinkViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/BackLink.cshtml", backLinkViewModel);
        }

        public static IHtmlContent GovUkBreadcrumbs(
            this IHtmlHelper htmlHelper,
            BreadcrumbsViewModel breadcrumbsViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Breadcrumbs.cshtml", breadcrumbsViewModel);
        }

        public static IHtmlContent GovUkButton(
            this IHtmlHelper htmlHelper,
            ButtonViewModel buttonViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Button.cshtml", buttonViewModel);
        }

        public static IHtmlContent GovUkCharacterCount(
            this IHtmlHelper htmlHelper,
            CharacterCountViewModel characterCountViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/CharacterCount.cshtml", characterCountViewModel);
        }

        public static IHtmlContent GovUkCharacterCountFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null)
            where TModel : class
        {
            return CharacterCountHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                rows,
                labelOptions,
                hintOptions,
                formGroupOptions);
        }

        public static IHtmlContent GovUkCheckboxes(
            this IHtmlHelper htmlHelper,
            CheckboxesViewModel checkboxesViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Checkboxes.cshtml", checkboxesViewModel);
        }

        public static IHtmlContent GovUkCheckboxesFor<TModel, TEnum>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, List<TEnum>>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            Dictionary<TEnum, Func<object, object>> conditionalOptions = null
            )
            where TModel : class
            where TEnum : Enum
        {
            return CheckboxesHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                fieldsetOptions,
                hintOptions,
                conditionalOptions);
        }

        public static IHtmlContent GovUkCheckboxItem(
            this IHtmlHelper htmlHelper,
            CheckboxItemViewModel checkboxItemViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/CheckboxItem.cshtml", checkboxItemViewModel);
        }

        public static IHtmlContent GovUkDateInput(
            this IHtmlHelper htmlHelper,
            DateInputViewModel dateInputViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/DateInput.cshtml", dateInputViewModel);
        }

        /// <summary>
        /// This doesn't work for more than three items and only if they have ids 'day', 'month', and 'year'.
        /// <returns></returns>
        public static IHtmlContent GovUkDateInputFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, DateTime?>> propertyLambdaExpression,
            string classes = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FieldsetViewModel fieldsetOptions = null,
            FormGroupViewModel formGroupOptions = null,
            Dictionary<string, string> attributes = null
            )
            where TModel : class
        {
            return DateInputHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                classes,
                labelOptions,
                hintOptions,
                fieldsetOptions,
                formGroupOptions,
                attributes);
        }

        public static IHtmlContent GovUkDetails(
            this IHtmlHelper htmlHelper,
            DetailsViewModel detailsViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Details.cshtml", detailsViewModel);
        }

        public static IHtmlContent GovUkErrorMessage(
            this IHtmlHelper htmlHelper,
            ErrorMessageViewModel errorMessageViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorMessage.cshtml", errorMessageViewModel);
        }

        public static IHtmlContent GovUkErrorSummary(
            this IHtmlHelper htmlHelper,
            ErrorSummaryViewModel errorSummaryViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorSummary.cshtml", errorSummaryViewModel);
        }

        public static IHtmlContent GovUkErrorSummary(
            this IHtmlHelper htmlHelper,
            ModelStateDictionary modelState,
            string[] optionalOrderOfPropertyNamesInTheView = null)
        {
            // Give 'optionalOrderOfPropertiesInTheView' a default value (of an empty array)
            var orderOfPropertyNamesInTheView = optionalOrderOfPropertyNamesInTheView ?? new string[0];

            return ErrorSummaryHtmlGenerator.GenerateHtml(htmlHelper, modelState, orderOfPropertyNamesInTheView);
        }

        public static IHtmlContent GovUkFieldset(
            this IHtmlHelper htmlHelper,
            FieldsetViewModel fieldsetViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Fieldset.cshtml", fieldsetViewModel);
        }

        public static IHtmlContent GovUkFooter(
            this IHtmlHelper htmlHelper,
            FooterViewModel footerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Footer.cshtml", footerViewModel);
        }

        public static IHtmlContent GovUkHeader(
            this IHtmlHelper htmlHelper,
            HeaderViewModel headerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Header.cshtml", headerViewModel);
        }

        public static IHtmlContent GovUkHint(
            this IHtmlHelper htmlHelper,
            HintViewModel hintViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Hint.cshtml", hintViewModel);
        }

        public static IHtmlContent GovUkHtmlText(
            this IHtmlHelper htmlHelper,
            IHtmlText htmlText)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/SubComponents/HtmlText.cshtml", htmlText);
        }

        public static IHtmlContent GovUkInsetText(
            this IHtmlHelper htmlHelper,
            InsetTextViewModel insetTextViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/InsetText.cshtml", insetTextViewModel);
        }

        public static IHtmlContent GovUkItem(
            this IHtmlHelper htmlHelper,
            ItemViewModel itemViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Item.cshtml", itemViewModel);
        }

        public static IHtmlContent GovUkItemSet(
            this IHtmlHelper htmlHelper,
            ItemSetViewModel itemSetViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ItemSet.cshtml", itemSetViewModel);
        }

        public static IHtmlContent GovUkLabel(
            this IHtmlHelper htmlHelper,
            LabelViewModel labelViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Label.cshtml", labelViewModel);
        }

        public static IHtmlContent GovUkLegend(
            this IHtmlHelper htmlHelper,
            LegendViewModel legendViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Legend.cshtml", legendViewModel);
        }

        public static IHtmlContent GovUkPanel(
            this IHtmlHelper htmlHelper,
            PanelViewModel panelViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Panel.cshtml", panelViewModel);
        }

        public static IHtmlContent GovUkPhaseBanner(
            this IHtmlHelper htmlHelper,
            PhaseBannerViewModel phaseBannerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/PhaseBanner.cshtml", phaseBannerViewModel);
        }

        public static IHtmlContent GovUkRadiosFor<TModel, TEnum>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            return RadiosHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                fieldsetOptions,
                hintOptions);
        }

        public static IHtmlContent GovUkRadioItem(
            this IHtmlHelper htmlHelper,
            RadioItemViewModel radioItemViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/RadioItem.cshtml", radioItemViewModel);
        }

        public static IHtmlContent GovUkSummaryList(
            this IHtmlHelper htmlHelper,
            SummaryListViewModel summaryListViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/SummaryList.cshtml", summaryListViewModel);
        }

        public static IHtmlContent GovUkTable(
            this IHtmlHelper htmlHelper,
            TableGovUkViewModel tableViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Table.cshtml", tableViewModel);
        }

        public static IHtmlContent GovUkTabs(
            this IHtmlHelper htmlHelper,
            TabsViewModel tabsViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Tabs.cshtml", tabsViewModel);
        }

        public static IHtmlContent GovUkTag(
            this IHtmlHelper htmlHelper,
            TagViewModel tagViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Tag.cshtml", tagViewModel);
        }

        public static IHtmlContent GovUkTextArea(
            this IHtmlHelper htmlHelper,
            TextAreaViewModel textAreaViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/TextArea.cshtml", textAreaViewModel);
        }

        public static IHtmlContent GovUkTextAreaFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null)
            where TModel : class
        {
            return TextAreaHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                rows,
                labelOptions,
                hintOptions,
                formGroupOptions);
        }

        public static IHtmlContent GovUkTextInput(
            this IHtmlHelper htmlHelper,
            TextInputViewModel textInputViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/TextInput.cshtml", textInputViewModel);
        }

        public static IHtmlContent GovUkTextInputFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null)
            where TModel : class
        {
            return TextInputHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyExpression,
                labelOptions,
                hintOptions,
                formGroupOptions,
                classes,
                textInputAppendix);
        }

        public static IHtmlContent GovUkTextInputFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, int?>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null)
            where TModel : class
        {
            return TextInputHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyExpression,
                labelOptions,
                hintOptions,
                formGroupOptions,
                classes,
                textInputAppendix);
        }

        public static IHtmlContent GovUkFileUpload(
            this IHtmlHelper htmlHelper,
            FileUploadViewModel fileUploadViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/FileUpload.cshtml", fileUploadViewModel);
        }

        public static IHtmlContent GovUkFileUploadFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, IFormFile>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null)
            where TModel : class
        {
            return FileUploadHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyExpression,
                labelOptions,
                hintOptions,
                formGroupOptions,
                classes);
        }
    }
}
