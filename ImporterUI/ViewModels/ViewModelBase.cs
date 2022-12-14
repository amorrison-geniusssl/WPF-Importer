using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImporterUI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public bool _canInsert;

        public bool CanInsert { get; set; }

        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task LoadFileAsync(string filePath)
        {
            return Task.CompletedTask;
        }

        public virtual Task InsertData()
        {
            return Task.CompletedTask;
        }
    }
}
