using ImporterDomain.Models;
using System;
using System.Collections.Generic;
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


        public int AccountNumber
        {
            get { return _model.AccountNumber; }
            set
            {
                _model.AccountNumber = value;
                RaisePropertyChanged();
                if ((_model.AccountNumber != 0))
                {
                    AddError("AccountNumber is required");
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
                if (string.IsNullOrEmpty(_model.AccountName))
                {
                    AddError("AccountName is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }
    }
}
