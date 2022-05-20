using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmployeeManagement.ViewModel.Helper
{
    public class EmptyInputRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isEmpty = (value == null || string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()));
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
            bool isMailID = mailIDPattern.IsMatch(value.ToString());
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
            bool isPhoneNum = phoneNumPattern.IsMatch(value.ToString());
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
