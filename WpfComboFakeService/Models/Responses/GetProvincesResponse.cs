using System.Collections.Generic;
using WpfComboFakeService.Models.DTOs;

namespace WpfComboFakeService.Models.Responses
{
    public class GetProvincesResponse : BaseResponse
    {
        public IEnumerable<ProvinceDTO> Provinces { get; set; }
    }
}
