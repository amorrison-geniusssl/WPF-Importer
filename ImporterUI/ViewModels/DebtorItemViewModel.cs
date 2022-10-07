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

        public DebtorItemViewModel(DebtorModel model)
        {
            _model = model;
        }

        public int AccountNumber 
        { 
            get { return _model.AccountNumber; } 
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
