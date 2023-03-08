using System.Collections.Generic;
using WpfComboFakeService.Models.DTOs;

namespace WpfComboFakeService.Models.Responses
{
    public class GetRegionsResponse : BaseResponse
    {
        public IEnumerable<RegionDTO> Regions { get; set; }
    }
}
