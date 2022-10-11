using ImporterUI.Commands;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ImporterUI.ViewModels
{
    public class MainViewModel : ValidationViewModelBase
    {
        private ValidationViewModelBase? viewModelBase;
        private string? _filePath;


        public MainViewModel(DebtorsViewModel debtorsViewModel, PaymentsViewModel paymentsViewModel)
        {
            DebtorsViewModel = debtorsViewModel;
            PaymentsViewModel = paymentsViewModel;

            SelectedViewModel = DebtorsViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
            SelectFilePath = new DelegateCommand(SelectPath);
            LoadSelectedFile = new DelegateCommand(DisplayFile);
            InsertData = new DelegateCommand(InsertFile);

            FilePath = "";
        }



        public ValidationViewModelBase? SelectedViewModel
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

                string rgx = @"^(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.(txt)$";

                if (string.IsNullOrEmpty(FilePath))
                {
                    AddError("File path is required to load data");
                }
                else if (!File.Exists(FilePath))
                {
                    AddError("File path is not valid and does not point to a .csv file");
                }
                else
                {
                    ClearErrors();
                }

                
            }
        }

        public DebtorsViewModel DebtorsViewModel { get; }
        public PaymentsViewModel PaymentsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }
        public DelegateCommand SelectFilePath { get; }
        public DelegateCommand LoadSelectedFile { get; }
        public DelegateCommand InsertData { get; }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ValidationViewModelBase;
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

        private async void InsertFile(object? obj)
        {
            if (SelectedViewModel == DebtorsViewModel)
            {
                await DebtorsViewModel.InsertData();
                FilePath = "";
                SelectedViewModel.LoadAsync();
            }

        }
    }
}