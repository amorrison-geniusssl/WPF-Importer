using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class DebtorItemViewModel : ValidationViewModelBase
    {
        private DebtorModel _model;

        public DebtorItemViewModel()
        {

        }

        public DebtorItemViewModel(DebtorModel model)
        {
            _model = model;
        }

        public DebtorItemViewModel(string? debtType, int accountNumber, string? accountName, string? birthDate, double? balance, string? email, long? phoneNumber, string? firstAddress, string? secondAddress, string? thirdAddress, string? postCode)
        {
            _model = new DebtorModel();

            _model.DebtType = debtType;
            AccountNumber = accountNumber;
            AccountName = accountName;
            BirthDate = birthDate;
            Balance = balance;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstAddress = firstAddress;
            SecondAddress = secondAddress;
            ThirdAddress = thirdAddress;
            PostCode = postCode;
        }

        public string? DebtType
        {
            get { return _model.DebtType; }
            set
            {
                _model.DebtType = value;
                RaisePropertyChanged();
            }
        }

        public int AccountNumber
        {
            get { return _model.AccountNumber; }
            set
            {
                _model.AccountNumber = value;
                RaisePropertyChanged();
            }
        }

        public string? AccountName
        {
            get { return _model.AccountName; }
            set
            {
                _model.AccountName = value;
                RaisePropertyChanged();
                if (string.IsNullOrEmpty(_model.AccountName) || _model.AccountName.Length <= 10) 
                {
                    AddError("AccountName is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? BirthDate 
        {
            get { return _model.BirthDate; }
            set
            {
                _model.BirthDate = value;
                RaisePropertyChanged();

                DateTime dt;
                if (!DateTime.TryParseExact(_model.BirthDate, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                {
                   AddError("DOB is invalid");
                }
                else
                {
                    ClearErrors();
                }  
            }
        }

        public double? Balance
        {
            get { return _model.Balance; }
            set
            {
                _model.Balance = value;
                RaisePropertyChanged();
            }
        }
        public string? Email
        {
            get { return _model.Email; }
            set
            {
                _model.Email = value;
                RaisePropertyChanged();
            }
        }

        public long? PhoneNumber
        {
            get { return _model.PhoneNumber; }
            set
            {
                _model.PhoneNumber = value;
                RaisePropertyChanged();
            }
        }

        public string? FirstAddress
        {
            get { return _model.FirstAddress; }
            set
            {
                _model.FirstAddress = value;
                RaisePropertyChanged();
            }
        }

        public string? SecondAddress
        {
            get { return _model.SecondAddress; }
            set
            {
                _model.SecondAddress = value;
                RaisePropertyChanged();
            }
        }

        public string? ThirdAddress
        {
            get { return _model.ThirdAddress; }
            set
            {
                _model.ThirdAddress = value;
                RaisePropertyChanged();
            }
        }

        public string? PostCode
        {
            get { return _model.PostCode; }
            set
            {
                _model.PostCode = value;
                RaisePropertyChanged();
            }
        }
    }
}
