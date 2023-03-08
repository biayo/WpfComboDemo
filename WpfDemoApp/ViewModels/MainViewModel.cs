using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Windows.Input;
using WpfComboFakeService;
using WpfComboFakeService.Models.Enums;
using WpfComboFakeService.Models.Requests;
using WpfDemoApp.Models;
using WpfDemoApp.Utils;

namespace WpfDemoApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private FakeService _da;

        private RegionModel _selectedRegion;
        public RegionModel SelectedRegion
        {
            get { return _selectedRegion; }
            set { SetProperty(ref _selectedRegion, value); }
        }

        private ProvinceModel _selectedProvince;
        public ProvinceModel SelectedProvince
        {
            get { return _selectedProvince; }
            set { SetProperty(ref _selectedProvince, value); }
        }

        public IEnumerable<RegionModel> Regions = new List<RegionModel>();
        public IEnumerable<ProvinceModel> Provinces = new List<ProvinceModel>();

        public ICommand GetRegions { get; private set; } // should use init but this is an old C# definition
        public ICommand GetProvinces { get; private set; }

        public MainViewModel()
        {
            _da = new FakeService();

            GetRegions = GetRegionsCommand;
            GetProvinces = GetProvincesCommand;
        }

        private RelayCommand GetRegionsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var response = _da.GetRegions();
                    if (response.Status == Status.Success)
                    {
                        Regions = response.Regions.MapFromDtoEnumerable();
                    }
                });
            }
        }
        private RelayCommand GetProvincesCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var request = new GetProvincesRequest
                    {
                        RegionId = this.SelectedRegion.Id,
                    };
                    var response = _da.GetProvinces(request);
                    if (response.Status == Status.Success)
                    {
                        Provinces = response.Provinces.MapFromDtoEnumerable();
                    }
                });
            }
        }
    }
}
