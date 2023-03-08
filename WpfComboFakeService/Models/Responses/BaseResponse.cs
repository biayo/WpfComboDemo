using WpfComboFakeService.Models.Enums;

namespace WpfComboFakeService.Models.Responses
{
    public class BaseResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; }
    }
}