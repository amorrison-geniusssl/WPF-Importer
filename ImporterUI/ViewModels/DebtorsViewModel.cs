using ImporterBusiness;
using ImporterDomain.Models;
using ImporterUI.Commands;
using ImporterUI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Xml.Linq;

namespace ImporterUI.ViewModels
{

    public class DebtorsViewModel : ValidationViewModelBase
    {
        private IDebtorRespository _debtorRepository;
        private DebtorItemViewModel? _selectedDebtor;

        public DebtorsViewModel(IDebtorRespository debtorRepository)
        {
            _debtorRepository = debtorRepository;
        }

        public ObservableCollection<DebtorItemViewModel> Debtors { get; } = new();


        public override async Task LoadAsync()
        {
            Debtors.Clear();

            var debtors = await _debtorRepository.GetAllAsync();
            if (debtors != null)
            {
                foreach (var debtor in debtors)
                {
                    Debtors.Add(new DebtorItemViewModel(_debtorRepository, debtor));
                }
            }
            CanInsert = false;
        }

        public override async Task LoadFileAsync(string filePath)
        {
            ProcessData file = new ProcessData();
            List<DebtorModel> debtors = new List<DebtorModel>();

            try
            {
                debtors = await file.ReadDebtorFileAsync(filePath);
                CanInsert = true;
            }
            catch (Exception)
            {
                var dg = new Action(() => { MessageBox.Show("Invalid Data:= Please enter a csv file with the correct Debtor fields"); });
                Dispatcher.CurrentDispatcher.BeginInvoke(dg);
                return;
            }

            Debtors.Clear();

            if (debtors != null)
            {
                foreach (var debtor in debtors)
                {
                    Thread.Sleep(5);
                    var newDebtor = new DebtorItemViewModel
                    (
                        _debtorRepository,
                        debtor.DebtType,
                        debtor.AccountNumber,
                        debtor.AccountName,
                        debtor.BirthDate,
                        debtor.Balance,
                        debtor.Email,
                        debtor.PhoneNumber,
                        debtor.FirstAddress,
                        debtor.SecondAddress,
                        debtor.ThirdAddress,
                        debtor.PostCode
                    );

                    Debtors.Add(newDebtor);
                }
            }

        }

        public override async Task InsertData()
        {
            foreach (var item in Debtors)
            {
                if(!item.HasErrors)
                {
                    _debtorRepository.Add(new DebtorModel
                        (
                            item.DebtType,
                            item.AccountNumber,
                            item.AccountName,
                            item.BirthDate,
                            item.Balance,
                            item.Email,
                            item.PhoneNumber,
                            item.FirstAddress,
                            item.SecondAddress, 
                            item.ThirdAddress,
                            item.PostCode
                        ));
                }
            }
            await _debtorRepository.SaveAsync();
        }


        public DebtorItemViewModel? SelectedDebtor
        {
            get => _selectedDebtor;
            set
            {
                _selectedDebtor = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsDebtorSelected));
            }
        }

        public bool IsDebtorSelected
        {
            get
            {
                return SelectedDebtor != null;
            }
        } 
    }
}
