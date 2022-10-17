using ImporterDomain.Models;
using ImporterUI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class DebtorItemViewModel : ItemViewModelBase
    {
        private DebtorModel _model;
        private IDebtorRespository _debtorRepository;


        public DebtorItemViewModel(IDebtorRespository debtorRepository, DebtorModel model)
        {
            _debtorRepository = debtorRepository;
            _model = model;
        }

        public DebtorItemViewModel(IDebtorRespository debtorRepository, string? debtType, int accountNumber, string? accountName, string? birthDate, double? balance, string? email, long? phoneNumber, string? firstAddress, string? secondAddress, string? thirdAddress, string? postCode)
        {
            _debtorRepository = debtorRepository;

            _model = new DebtorModel();

            DebtType = debtType;
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

                if (NoValidationErrors(DebtType, "DebtType", _model, null) == false)
                {
                    AddError($"DebtType is invalid");
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

                bool debtorExists = _debtorRepository.ItemExists(AccountNumber);

                if (NoValidationErrors(AccountNumber, "AccountNumber", _model, null) == false || debtorExists == true)
                {
                    AddError($"AccountNumber is invalid");
                }
                else
                {
                    ClearErrors();
                }

            }
        }

        public string? AccountName
        {
            get { return _model.AccountName; }
            set
            {
                _model.AccountName = value;
                RaisePropertyChanged();

                if (NoValidationErrors(AccountName, "DebtType", _model, null) == false)
                {
                    AddError($"AccountName is invalid");
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


                if (NoValidationErrors(BirthDate, "BirthDate", _model, null) == false || 
                    !DateTime.TryParseExact(_model.BirthDate, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                {
                    AddError($"BirthDate is invalid");
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

                if (NoValidationErrors(Balance, "Balance", _model, null) == false)
                {
                    AddError($"Balance  is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }
        public string? Email
        {
            get { return _model.Email; }
            set
            {
                _model.Email = value;
                RaisePropertyChanged();

                if (NoValidationErrors(Email, "Email", _model, null) == false)
                {
                    AddError($"Email is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public long? PhoneNumber
        {
            get { return _model.PhoneNumber; }
            set
            {
                _model.PhoneNumber = value;
                RaisePropertyChanged();

                if (NoValidationErrors(PhoneNumber, "PhoneNumber", _model, null) == false)
                {
                    AddError($"PhoneNumber is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? FirstAddress
        {
            get { return _model.FirstAddress; }
            set
            {
                _model.FirstAddress = value;
                RaisePropertyChanged();

                if (NoValidationErrors(FirstAddress, "FirstAddress", _model, null) == false)
                {
                    AddError($"FirstAddress is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? SecondAddress
        {
            get { return _model.SecondAddress; }
            set
            {
                _model.SecondAddress = value;
                RaisePropertyChanged();

                if (NoValidationErrors(SecondAddress, "SecondAddress", _model, null) == false)
                {
                    AddError($"SecondAddress is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? ThirdAddress
        {
            get { return _model.ThirdAddress; }
            set
            {
                _model.ThirdAddress = value;
                RaisePropertyChanged();

                if (NoValidationErrors(ThirdAddress, "ThirdAddress", _model, null) == false)
                {
                    AddError($"ThirdAddress is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? PostCode
        {
            get { return _model.PostCode; }
            set
            {
                _model.PostCode = value;
                RaisePropertyChanged();

                if (NoValidationErrors(ThirdAddress, "ThirdAddress", _model, null) == false)
                {
                    AddError($"ThirdAddress is invalid");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

    }
}
