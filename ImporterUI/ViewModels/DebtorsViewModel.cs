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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Xml.Linq;

namespace ImporterUI.ViewModels
{

    public class DebtorsViewModel : ViewModelBase
    {
        private DebtorModel _debtor;
        private IDebtorRespository _debtorRepository;
        private DebtorItemViewModel? _selectedDebtor;

        public DebtorsViewModel(IDebtorRespository debtorRepository)
        {
            _debtorRepository = debtorRepository;
        }

        public ObservableCollection<DebtorModel> Debtors { get; } = new();


        public override async Task LoadAsync()
        {
            Debtors.Clear();

            var debtors = await _debtorRepository.GetAllAsync();
            if (debtors != null)
            {
                foreach (var debtor in debtors)
                {
                    Debtors.Add(debtor);
                }
            }
        }

        public override async Task LoadFileAsync(string filePath)
        {
            ProcessData file = new ProcessData();
            List<DebtorModel> debtors = new List<DebtorModel>();

            try
            {
                 debtors = await file.ReadDebtorFileAsync(filePath);
            }
            catch(Exception)
            {
                var dg = new Action(() => { MessageBox.Show("Invalid Data:- Please enter a csv file with the correct Debtor fields"); });
                Dispatcher.CurrentDispatcher.BeginInvoke(dg);
                return;
            }

            Debtors.Clear();

            if (debtors != null)
            {
                foreach (var debtor in debtors)
                {
                    Debtors.Add(debtor);
                }
            }
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

        /*
                protected override async void OnSaveExecute()
                {
                    await SaveWithOptimisticConcurrencyAsync(_friendRepository.SaveAsync,
                      () =>
                      {
                          HasChanges = _friendRepository.HasChanges();
                          Id = Friend.Id;
                          RaiseDetailSavedEvent(Friend.Id, $"{Friend.FirstName} {Friend.LastName}");
                      });
                }

                protected override bool OnSaveCanExecute()
                {
                    return Friend != null
                      && !Friend.HasErrors
                      && PhoneNumbers.All(pn => !pn.HasErrors)
                      && HasChanges;
                }

                protected override async void OnDeleteExecute()
                {
                    if (await _friendRepository.HasMeetingsAsync(Friend.Id))
                    {
                        await MessageDialogService.ShowInfoDialogAsync($"{Friend.FirstName} {Friend.LastName} can't be deleted, as this friend is part of at least one meeting");
                        return;
                    }

                    var result = await MessageDialogService.ShowOkCancelDialogAsync($"Do you really want to delete the friend {Friend.FirstName} {Friend.LastName}?",
                      "Question");
                    if (result == MessageDialogResult.OK)
                    {
                        _friendRepository.Remove(Friend.Model);
                        await _friendRepository.SaveAsync();
                        RaiseDetailDeletedEvent(Friend.Id);
                    }
                }

                private Friend CreateNewFriend()
                {
                    var friend = new Friend();
                    _friendRepository.Add(friend);
                    return friend;
                }
        */
    }
}
