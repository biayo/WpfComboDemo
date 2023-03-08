using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDemoApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T privateField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(privateField, value))
                return false;

            privateField = value;

            this.OnPropertyChanged(propertyName);

            return true;
        }
    }
}