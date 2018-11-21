using System;
using System.ComponentModel.DataAnnotations;

namespace Daybook.WebApp.Core.ViewModels.Validations
{
    public class FutureDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            string[] yyyymm = value.ToString().Split('/');
            int yyyy, mm;
            yyyy = Convert.ToInt32(yyyymm[0]);
            mm = Convert.ToInt32(yyyymm[1]);

            return (new DateTime(yyyy, mm, 1) > DateTime.Now);

        }
    }
}