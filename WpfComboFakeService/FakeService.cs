using System.Collections.Generic;
using System.Linq;
using WpfComboFakeService.Models.Enums;
using WpfComboFakeService.Models.DTOs;
using WpfComboFakeService.Models.Requests;
using WpfComboFakeService.Models.Responses;

namespace WpfComboFakeService
{
    public class FakeService : IFakeService
    {
        private readonly List<RegionDTO> _regions = new List<RegionDTO>();
        private readonly List<ProvinceDTO> _provinces = new List<ProvinceDTO>();

        public FakeService()
        {
            PopulateRegions();
            PopulateProvinces();
        }

        private void PopulateRegions()
        {
            _regions.Add(new RegionDTO { Id = 1, Name = "Lombardia" });
            _regions.Add(new RegionDTO { Id = 2, Name = "Lazio" });
            _regions.Add(new RegionDTO { Id = 3, Name = "Piemonte" });
            _regions.Add(new RegionDTO { Id = 4, Name = "Toscana" });
            _regions.Add(new RegionDTO { Id = 5, Name = "Liguria" });
        }
        private void PopulateProvinces()
        {
            _provinces.Add(new ProvinceDTO { Id = 1, Name = "Milano", RegionId = 1 });
            _provinces.Add(new ProvinceDTO { Id = 2, Name = "Bergamo", RegionId = 1 });
            _provinces.Add(new ProvinceDTO { Id = 3, Name = "Monza", RegionId = 1 });
            _provinces.Add(new ProvinceDTO { Id = 4, Name = "Roma", RegionId = 2 });
            _provinces.Add(new ProvinceDTO { Id = 5, Name = "Viterbo", RegionId = 2 });
            _provinces.Add(new ProvinceDTO { Id = 6, Name = "Torino", RegionId = 3 });
            _provinces.Add(new ProvinceDTO { Id = 7, Name = "Alessandria", RegionId = 3 });
            _provinces.Add(new ProvinceDTO { Id = 8, Name = "Vercelli", RegionId = 3 });
            _provinces.Add(new ProvinceDTO { Id = 9, Name = "Livorno", RegionId = 4 });
            _provinces.Add(new ProvinceDTO { Id = 10, Name = "Pistoia", RegionId = 4 });
            _provinces.Add(new ProvinceDTO { Id = 11, Name = "Lucca", RegionId = 4 });
            _provinces.Add(new ProvinceDTO { Id = 12, Name = "Genova", RegionId = 5 });
            _provinces.Add(new ProvinceDTO { Id = 13, Name = "Savona", RegionId = 5 });
        }

        public GetRegionsResponse GetRegions()
        {
            return new GetRegionsResponse
            {
                Message = "OK",
                Regions = _regions.AsEnumerable(),
                Status = Status.Success
            };
        }
        public GetProvincesResponse GetProvinces(GetProvincesRequest request)
        {
            var result = _provinces.Where(p => request.RegionId == default || p.RegionId == request.RegionId)
                                   .ToList()
                                   .AsEnumerable();

            return new GetProvincesResponse
            {
                Message = result.Any() ? "OK" : "KO",
                Provinces = result,
                Status = result.Any() ? Status.Success : Status.Failed,
            };
        }
    }
}
