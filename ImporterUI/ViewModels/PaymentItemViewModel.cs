using ImporterDomain.Models;
using ImporterUI.Data;
using System.Globalization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Data;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class PaymentItemViewModel : ItemViewModelBase
    {
        private IPaymentRespository _paymentRepository;
        private PaymentModel _model;

        public PaymentItemViewModel(IPaymentRespository paymentRepository, PaymentModel model)
        {
            _paymentRepository = paymentRepository;
            _model = model;
        }

        public PaymentItemViewModel(IPaymentRespository paymentRepository, string adeptRef, double? amount, string effectiveDate, string source, string method, string comment, int accountNumber)
        {
            _paymentRepository = paymentRepository;
            _model = new PaymentModel();

            AdeptRef = adeptRef;
            Amount = amount;
            EffectiveDate = effectiveDate;
            Source = source;
            Method = method;
            Comment = comment;
            AccountNumber = accountNumber;
        }


        public string AdeptRef
        {
            get { return _model.AdeptRef; }
            set
            {
                _model.AdeptRef = value;
                RaisePropertyChanged();

                CheckPaymentExists();

                if (NoValidationErrors(AdeptRef, "AdeptRef", null, _model) == false || PaymentExists == true)
                {
                    AddError($"AdeptRef is invalid");
                }
                else
                {
                    ClearErrors();
                }

            }
        }

        public double? Amount
        {
            get { return _model.Amount; }
            set
            {
                _model.Amount = value;
                RaisePropertyChanged();

                if (NoValidationErrors(Amount, "Amount", null, _model) == false)
                {
                    AddError($"Amount is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string EffectiveDate
        {
            get { return _model.EffectiveDate; }
            set
            {
                _model.EffectiveDate = value;
                RaisePropertyChanged();

                if (NoValidationErrors(EffectiveDate, "EffectiveDate", null, _model) == false)
                {
                    AddError($"EffectiveDate is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string Source
        {
            get { return _model.Source; }
            set
            {
                _model.Source = value;
                RaisePropertyChanged();

                if (NoValidationErrors(Source, "Source", null, _model) == false)
                {
                    AddError($"Source is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string Method
        {
            get { return _model.Method; }
            set
            {
                _model.Method = value;
                RaisePropertyChanged();

                if (NoValidationErrors(Method, "Method", null, _model) == false)
                {
                    AddError($"Method is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string Comment
        {
            get { return _model.Comment; }
            set
            {
                _model.Comment = value;
                RaisePropertyChanged();

                if (NoValidationErrors(Comment, "Comment", null, _model) == false)
                {
                    AddError($"Comment is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public int AccountNumber
        {
            get { return _model.AccountNumber; }
            set
            {
                _model.AccountNumber = value;
                RaisePropertyChanged();

                // Checks the reference account number matches a user in the user table
                CheckUserExists();

                if (NoValidationErrors(AccountNumber, "AccountNumber", null, _model) == false || UserExists == false)
                {
                    AddError($"AccountNumber is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        private bool UserExists { get; set; }
        private bool PaymentExists { get; set; }
        private async void CheckUserExists()
        {
            UserExists = await _paymentRepository.ForeignKeyExistsAsync(AccountNumber);
        }

        private async void CheckPaymentExists()
        { 
            PaymentExists = await _paymentRepository.ItemExistsAsync(AdeptRef);
        }
    }
}