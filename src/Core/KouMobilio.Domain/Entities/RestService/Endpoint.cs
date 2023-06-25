using KouMobilio.Domain.Entities.Common;

namespace KouMobilio.Domain.Entities.RestService;

public class Endpoint : BaseEntity
{
    public string Url { get; set; }
    public EndpointHttpMethod Method { get; set; }
    public Guid RestServiceConfigId { get; set; }
    public virtual RestServiceConfig Config { get; set; }
}