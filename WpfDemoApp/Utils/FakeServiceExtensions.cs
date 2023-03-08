using System.Collections.Generic;
using System.Linq;
using WpfComboFakeService.Models.DTOs;
using WpfDemoApp.Models;

namespace WpfDemoApp.Utils
{
    public static class FakeServiceExtensions
    {
        public static IEnumerable<RegionModel> MapFromDtoEnumerable(this IEnumerable<RegionDTO> @this)
        {
            return @this.Select(dto => new RegionModel { Id = dto.Id, Name = dto.Name, });
        }

        public static IEnumerable<ProvinceModel> MapFromDtoEnumerable(this IEnumerable<ProvinceDTO> @this)
        {
            return @this.Select(dto => new ProvinceModel { Id = dto.Id, Name = dto.Name, RegionId = dto.RegionId });
        }
    }
}
