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
        private ItemViewModelBase? itemViewModel;
        private string? _filePath;
        private string? _viewName;

        public MainViewModel(DebtorsViewModel debtorsViewModel, PaymentsViewModel paymentsViewModel)
        {
            DebtorsViewModel = debtorsViewModel;
            PaymentsViewModel = paymentsViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
            SelectFilePath = new DelegateCommand(SelectPath);
            LoadSelectedFile = new DelegateCommand(DisplayFile, CanDisplay);
            InsertData = new DelegateCommand(InsertFile, CanInsert);

            SelectedViewModel = DebtorsViewModel;
            //_viewName = $"Debtors";

            FilePath = "";
        }



        public ValidationViewModelBase? SelectedViewModel
        {
            get { return viewModelBase; }
            set
            {
                viewModelBase = value;
                RaisePropertyChanged();

                if (SelectedViewModel == DebtorsViewModel)
                {
                    ViewName = "Insert Debtors";
                }
                else if (SelectedViewModel == PaymentsViewModel)
                {
                    ViewName = "Insert Payments";

                }
            }
        }

        public string? FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                RaisePropertyChanged();
                LoadSelectedFile.RaiseCanExecuteChanged();


                if (!File.Exists(FilePath) && !string.IsNullOrEmpty(FilePath))
                {
                    AddError("File path is not valid and does not point to a valid file path file");
                    return;
                }
                else
                {
                    ClearErrors();
                }

                string? lastFour = System.IO.Path.GetExtension(FilePath);

                if ((lastFour != ".csv") && !string.IsNullOrEmpty(FilePath))
                {
                    AddError("File path is valid but does not point to a .csv file");
                    return;
                }
                else
                {
                    ClearErrors();
                }

                if (string.IsNullOrEmpty(FilePath))
                {
                    AddError("File path is required to load data");
                    return;
                }
                else
                {
                    ClearErrors();
                }
            }
        }


        public string? ViewName
        {
            get { return _viewName; }
            set 
            { 
                _viewName = value;
                RaisePropertyChanged();

                
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
            await SelectedViewModel.LoadAsync();
            
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
            await SelectedViewModel.LoadFileAsync(FilePath);
            InsertData.RaiseCanExecuteChanged();
        }

        private bool CanDisplay(object? obj)
        {
            return FilePath != "";
        }

        private async void InsertFile(object? obj)
        {
            if (SelectedViewModel == DebtorsViewModel)
            {
                await DebtorsViewModel.InsertData();
                
            }
            else if(SelectedViewModel == PaymentsViewModel)
            {
                await PaymentsViewModel.InsertData();
            }

            FilePath = "";
            await SelectedViewModel.LoadAsync();
            InsertData.RaiseCanExecuteChanged();
        }

        private bool CanInsert(object? obj)
        {
            return SelectedViewModel != null && FilePath != "" && SelectedViewModel.CanInsert == true; 
        }
    }
}