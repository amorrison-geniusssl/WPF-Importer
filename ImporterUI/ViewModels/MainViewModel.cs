using ImporterUI.Commands;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? viewModelBase;


        public MainViewModel(DebtorsViewModel debtorsViewModel)
        {
            DebtorsViewModel = debtorsViewModel;
            SelectedViewModel = DebtorsViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
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
        public DebtorsViewModel DebtorsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }

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
    }
}