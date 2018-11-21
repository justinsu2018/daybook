using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Daybook.WebApp.Core.ViewModels.Validations
{
    public class AmountValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            double intValue = Convert.ToDouble(value.ToString().Replace(",", ""));

            var isValid = false;

            if (intValue > 0)
            {
                var strValue = Convert.ToString(value).Replace(",", "");

                int dotcount = strValue.Count(s => s == '.');

                switch(dotcount)
                {
                    case 0:
                        isValid = true;
                        break;
                    case 1:
                        string[] valueArray = strValue.Split('.');

                        switch(valueArray.Length)
                        {
                            case 1:
                            case 2:
                                isValid = true;
                                break;
                            default:
                                isValid = false;
                                break;
                        }
                        break;
                    default:
                        isValid = false;
                        break;
                }
            }

            return isValid;

        }
    }
}