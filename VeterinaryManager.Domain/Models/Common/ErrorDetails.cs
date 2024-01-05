using Newtonsoft.Json;

namespace VeterinaryManager.Domain.Models.Common
{
    public class ErrorDetails
    {
        public int Code { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}