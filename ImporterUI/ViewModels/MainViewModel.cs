using ImporterUI.Commands;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? viewModelBase;
        private string? _filePath;


        public MainViewModel(DebtorsViewModel debtorsViewModel, PaymentsViewModel paymentsViewModel)
        {
            DebtorsViewModel = debtorsViewModel;
            PaymentsViewModel = paymentsViewModel;

            SelectedViewModel = DebtorsViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
            SelectFilePath = new DelegateCommand(SelectPath);
            LoadSelectedFile = new DelegateCommand(DisplayFile);
        }


        public ViewModelBase? SelectedViewModel
        {
            get { return viewModelBase; }
            set
            {
                viewModelBase = value;
                RaisePropertyChanged();
            }
        }

        public string? FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                RaisePropertyChanged();

            }
        }

        public DebtorsViewModel DebtorsViewModel { get; }
        public PaymentsViewModel PaymentsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }
        public DelegateCommand SelectFilePath { get; }
        public DelegateCommand LoadSelectedFile { get; }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        private void SelectPath(object? obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".csv";
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";

            var path = openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
        }

        private async void DisplayFile(object? obj)
        {
            
            if (SelectedViewModel != null && FilePath != null)
            {
                await SelectedViewModel.LoadFileAsync(FilePath);
            }
        }

    }
}