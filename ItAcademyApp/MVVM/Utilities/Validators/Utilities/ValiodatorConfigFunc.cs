using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ItAcademyApp.MVVM.Utilities.Validators.Utilities
{
    public static class ValiodatorConfigFunc
    {
        public static bool IsMatch(string value, Regex RegexConfig)
        {
            if (!(RegexConfig.IsMatch(value)))
            {
                return true;
            }
            return false;
        }
        public static bool IsMatch(string value, int minLength, int maxLength)
        {
            if((value.ToString().Length < minLength || value.ToString().Length > maxLength))
            {
                return true;
            }
            return false;
        }
    }
}
