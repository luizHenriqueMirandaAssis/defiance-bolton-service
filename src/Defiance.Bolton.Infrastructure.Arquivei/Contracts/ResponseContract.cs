using System.Collections.Generic;

namespace Defiance.Bolton.Infrastructure.Arquivei.Contracts
{
    public class ResponseContract
    {
        public StatusContract Status { get; set; }
        public List<NFeContract> Data { get; set; }
        public PageContract Page { get; set; }
        public int Count { get; set; }
        public string Signature { get; set; }

        public static ResponseContract Empty()
        {
            return new ResponseContract()
            {
                Data = new List<NFeContract>() { }
            };
        }
    }
}
