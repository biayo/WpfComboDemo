using WpfComboFakeService.Models.Requests;
using WpfComboFakeService.Models.Responses;

namespace WpfComboFakeService
{
    public interface IFakeService
    {
        GetRegionsResponse GetRegions();
        GetProvincesResponse GetProvinces(GetProvincesRequest request);
    }
}