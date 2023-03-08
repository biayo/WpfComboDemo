using Caliburn.Micro;
using System.Windows;
using WpfComboDemo.ViewModels;

namespace WpfComboDemo
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ComboDemoViewModel>();
        }
    }
}
