using EmployeeManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace EmployeeManagementMVVM.ViewModel.Helper
{
    static class ValidationUtil
    {
        public static object ExtractPropertyValue(object value)
        {
            /*Getting value from binding expression. The Validation step is changed to UpdatedValue so the "value" will be obtained as Binding expression
             and not we have to obtain the string value from it. https://stackoverflow.com/questions/10342715/validationrule-with-validationstep-updatedvalue-is-called-with-bindingexpressi#:~:text=And%20finally%2C%20the%20new%20RequiredRule%3A */

            BindingExpression binding = (BindingExpression)value;
            object dataItem = binding.DataItem;
            string propertyName = binding.ParentBinding.Path.Path;
            object propertyValue = dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
            return propertyValue;
        }
    }

    /// <summary>
    /// Validation of empty input
    /// </summary>
    public class EmptyInputRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string propertyValue = ValidationUtil.ExtractPropertyValue(value).ToString();
            bool isEmpty = (propertyValue == null || string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue));
            if (isEmpty)
            {
                return new ValidationResult(false, "Input is not valid");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    /// <summary>
    /// Validaiton of emailID
    /// </summary>
    public class EmailIDRule : ValidationRule
    {
        static Regex mailIDPattern;
        static EmailIDRule()
        {
            //Create a RegEx pattern for mail ID 
            mailIDPattern = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string propertyValue = ValidationUtil.ExtractPropertyValue(value).ToString();
            bool isMailID = mailIDPattern.IsMatch(propertyValue);
            if (!isMailID)
            {
                return new ValidationResult(false, "Input is not a valid email ID");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }

    /// <summary>
    /// Validation of phone number
    /// </summary>
    public class PhoneNumberRule : ValidationRule
    {
        static Regex phoneNumPattern;
        static PhoneNumberRule()
        {
            //Create a RegEx pattern for mail ID 
            phoneNumPattern = new Regex(@"^[0-9]{10}$", RegexOptions.IgnoreCase);
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string propertyValue = ValidationUtil.ExtractPropertyValue(value).ToString();
            bool isPhoneNum = phoneNumPattern.IsMatch(propertyValue);
            if (!isPhoneNum)
            {
                return new ValidationResult(false, "Input is not a valid phone number");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }


}
