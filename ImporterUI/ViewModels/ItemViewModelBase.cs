using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class ItemViewModelBase : ValidationViewModelBase
    {
        public bool NoValidationErrors(object cellValue, string propertyName, DebtorModel? debtorModel, PaymentModel? paymentModel)
        {
            var results = new List<ValidationResult>();
            ValidationContext context = null;

            if (debtorModel== null)
            {
                context = new ValidationContext(paymentModel) { MemberName = propertyName };
            }
            else if (paymentModel == null)
            {
                context = new ValidationContext(debtorModel) { MemberName = propertyName };
            }

            bool noAnnotationError = Validator.TryValidateProperty(cellValue, context, results);

            return noAnnotationError;
        }
    }
}
