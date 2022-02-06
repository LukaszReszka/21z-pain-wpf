using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAIN21Z_WPF2.ViewModels
{
    public class VelocityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ulong v;
            try
            {
                v = ulong.Parse(value.ToString());
            }
            catch(Exception)
            {
                return new ValidationResult(false, "Podaj całkowitą liczbę nieujemną");
            }

            return ValidationResult.ValidResult;
        }
    }
}
