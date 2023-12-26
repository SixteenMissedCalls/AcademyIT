using ItAcademyApp.MVVM.Utilities.Validators.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItAcademyApp.MVVM.Utilities.Validators.TextBoxesValidators
{
    internal class TextBoxValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (ValiodatorConfigFunc.IsMatch((string)value, new Regex("^[А-Яа-я]+$")))
            {
                return new ValidationResult(false, "Пожалуйста введите корректные данные");
            }
            if(ValiodatorConfigFunc.IsMatch((string)value, 2, 25)) 
            {
                return new ValidationResult(false, "Допустимая длина от 2 до 25 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}
