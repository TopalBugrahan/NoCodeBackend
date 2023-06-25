using KouMobilio.Domain.Entities.Common;
using KouMobilio.Domain.Entities.RestService.ValueObjects;

namespace KouMobilio.Domain.Entities.RestService;

public class RestServiceConfig : BaseEntity
{
    public List<HttpParameter> Parameters { get; set; }
    public Guid ProjectId{ get; set; }
    public virtual ICollection<Endpoint> Endpoints{ get; set; }
}